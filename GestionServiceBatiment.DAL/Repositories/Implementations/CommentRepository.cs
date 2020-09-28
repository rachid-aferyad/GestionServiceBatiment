﻿using GestionServiceBatiment.DAL.Mappers;
using GestionServiceBatiment.DAL.Models;
using GestionServiceBatiment.DAL.Repositories.Interfaces;
using GestionServiceBatiment.DAL.Views;
using GestionServiceBatiment.DAL.Views.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Connections.Database;

namespace GestionServiceBatiment.DAL.Repositories.Implementations
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public bool Delete(int id)
        {
            Command command = new Command("CSP_DeleteComment");
            //command.AddParameter("Table", "Comment");
            command.AddParameter("Id", id);
            return _connection.ExecuteNonQuery(command) > 0;
        }

        public IEnumerable<Comment> GetAll()
        {
            Command command = new Command("CSP_GetAll");
            command.AddParameter("Table", "Comment");
            return _connection.ExecuteReader(command, reader => reader.MapTo<Comment>());
        }
        
        public Comment GetById(int id)
        {
            Command command = new Command("CSP_GetById");
            command.AddParameter("Table", "Comment");
            command.AddParameter("Id", id);
            return _connection.ExecuteReader(command, reader => reader.MapTo<Comment>()).SingleOrDefault();
        }

        public IEnumerable<VComment> GetByCreator(int creatorId)
        {
            Command command = new Command("CSP_GetByUser");
            command.AddParameter("Table", "V_Comment");
            command.AddParameter("creatorId", creatorId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<VComment>());
        }

        public IEnumerable<VComment> GetByCompany(int companyId)
        {
            Command command = new Command("CSP_GetByCompany");
            command.AddParameter("Table", "V_Comment");
            command.AddParameter("CompanyId", companyId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<VComment>());
        }

        public IEnumerable<VComment> GetByRequest(int requestId)
        {
            Command command = new Command("CSP_GetByRequest");
            command.AddParameter("Table", "V_Comment");
            command.AddParameter("RequestId", requestId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<VComment>());
        }

        public IEnumerable<VComment> GetByService(int serviceId)
        {
            Command command = new Command("CSP_GetByService");
            command.AddParameter("Table", "V_Comment");
            command.AddParameter("ServiceId", serviceId); 
            IEnumerable<VComment> comments = _connection.ExecuteReader(command, reader => reader.MapTo<VComment>());
            return comments;
        }

        public IEnumerable<VComment> GetSubByParent(int parentId)
        {
            Command command = new Command("CSP_GetCommentByParent");
            //command.AddParameter("Table", "Category");
            command.AddParameter("ParentId", parentId);
            return _connection.ExecuteReader(command, reader => reader.MapTo<VComment>());
        }
        
        public IEnumerable<VComment> GetLatestReviews()
        {
            Command command = new Command("CSP_GetLatestReviews");
            return _connection.ExecuteReader(command, reader => reader.MapTo<VComment>());
        }

        public int Insert(Comment comment)
        {
            Command command = new Command("CSP_AddComment");
            command.AddParameter("Content", comment.Content);
            command.AddParameter("CreatorId", comment.CreatorId);
            command.AddParameter("ParentId", comment.ParentId);
            command.AddParameter("CompanyId", comment.CompanyId);
            command.AddParameter("ServiceId", comment.ServiceId);
            command.AddParameter("RequestId", comment.RequestId);
            command.AddParameter("Star", comment.Star);
            return (int)_connection.ExecuteScalar(command);
        }

        public bool Update(Comment comment)
        {
            Command command = new Command("CSP_UpdateComment");
            command.AddParameter("Id", comment.Id);
            command.AddParameter("Content", comment.Content);
            command.AddParameter("Star", comment.Star);
            return _connection.ExecuteNonQuery(command) > 0;

        }

    }
}
