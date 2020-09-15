﻿using GestionServiceBatiment.DAL.Mappers;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections.Database;

namespace GestionServiceBatiment.DAL.Repositories.Implementations
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {

        public bool Delete(int id)
        {
            Command command = new Command("CSP_DeleteCategory");
            //command.AddParameter("Table", "Category");
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Category> GetAll()
        {
            Command command = new Command("CSP_GetAllCategories");
            return _connection.ExecuteReader(command, reader => reader.MapTo<Category>());
        }

        public IEnumerable<Category> GetSup()
        {
            Command command = new Command("CSP_GetSupCategories");
            return _connection.ExecuteReader(command, reader => reader.MapTo<Category>());
        }

        public IEnumerable<Category> GetSub(int categoryId)
        {
            Command command = new Command("CSP_GetByParent");
            //command.AddParameter("Table", "Category");
            command.AddParameter("ParentId", categoryId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Category>());
        }

        public IEnumerable<Category> GetSubByParentName(string parentName)
        {
            Command command = new Command("CSP_GetByParentName");
            //command.AddParameter("Table", "Category");
            command.AddParameter("ParentName", parentName);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Category>());
        }

        public Category GetById(int id)
        {
            Command command = new Command("CSP_GetCategoryById");
            //command.AddParameter("Table", "Category");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Category>()).SingleOrDefault();
        }

        public Category GetByName(string name)
        {
            Command command = new Command("CSP_GetCategoryByName");
            //command.AddParameter("Table", "Category");
            command.AddParameter("Name", name);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Category>()).SingleOrDefault();
        }

        public IEnumerable<Category> GetByService(int serviceId)
        {
            Command command = new Command("CSP_GetByService");
            command.AddParameter("Table", "Category");
            command.AddParameter("ServiceId", serviceId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Category>());
        }

        public int Insert(Category entity)
        {
            Command command = new Command("CSP_AddCategory");
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Description", entity.Description);
            command.AddParameter("ParentId", entity.ParentId);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(Category entity)
        {
            Command command = new Command("CSP_UpdateCategory");
            command.AddParameter("Id", entity.Id);
            command.AddParameter("Name", entity.Name);
            command.AddParameter("Description", entity.Description);
            return _connection.ExecuteNonQuery(command) > 0;

        }
    }
}
