using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using CreateHomePage.Models;

namespace CreateHomePage
{
    public class EFPlayersRepository
    {
        private Models.EFDbContext context;
        //private SetPlayers context;

        public EFPlayersRepository()
        {
            // иниализируем созданное поля, передаём строку подключения - выбираем из конфиг файла первое подключение
            context = new Models.EFDbContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);       
            //тестовая инициализация без БД
            //context = new SetPlayers();
        }

        // выбиираем все записи
        public IEnumerable<Models.Player> GetPlayers()
        {           
            return context.Players.OrderBy(x =>x.Rating);
        }

        public Models.Player GetPlayerBy_Name(string name)
        {
            return context.Players.FirstOrDefault(x => x.Name == name);
        }

        public Models.Player GetPlayerBy_ID(int id)
        {
            return context.Players.ToList().Find(x => x.ID == id);
        }

        public void Update(Player model)
        {
            var oldModel = context.Players.ToList().Find(x => x.ID == model.ID);
            //if (oldModel) return null;
            context.Players.Remove(oldModel);
            context.Players.Add(model);
            //context.SaveChanges();
        }

        public void Delete(Player model)
        {
            var modelForDelete = context.Players.ToList().Find(x => x.ID == model.ID);
            context.Players.Remove(modelForDelete);
            context.SaveChanges();
        }

        public void Create(Player model)
        {
            if (context.Players.ToList().Exists(x => x.Name == model.Name))
            {
                throw new InvalidOperationException();
            }
            model.ID = context.Players.Max(x => x.ID) + 1;
            
            context.Players.Add(model);
            context.SaveChanges();
        }

        public void SavePlayer(Player model)
        {
            if (model.ID == 0)
            {
                context.Players.Add(model);
            }
            else
            {
                Player dbEntry = context.Players.Find(model.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = model.Name;
                    dbEntry.Rating = model.Rating;
                    dbEntry.CountToutnament = model.CountToutnament;
                    dbEntry.Action = model.Action;
                }
            }
            context.SaveChanges();
        }

    }
}