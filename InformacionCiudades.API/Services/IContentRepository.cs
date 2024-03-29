﻿using Contents.API.Entities;
using Contents.API.Models;

namespace Contents.API.Services
{
    public interface IContentRepository
    {
        public IEnumerable<User> GetUsers();
        public User? GetUser(int idUser);

        public void CreateUser(User user);

        public IEnumerable<Content> GetContents();
        public Content? GetContent(int idContent);
        public void CreateContent(Content content);
        public bool SaveChanges();
        public void DeleteUser(int idUser);

        public void DeleteContent(int idContent);
        public bool UserExists(int idUser);
        public bool UserNameExists(string username);
        public void AddContentToUser(int idUser, Content content);

        public Content? GetContentInUser(int idUser, int idContent);

        public bool ContentExists(int idContent);
        public User? ValidateCredentials(string username, string password);
        public int UsedTime(int userId);
        public IEnumerable <Review> GetReviews();
        public Review? GetReview(int idReview);
        public void AddReviewToContent(int idContent, Review review);
        public void DeleteReview(int idReview);
        public Review? GetReviewsInUser(int idUser, int idReview);
        public Review? GetReviewInContent(int idContent, int idReview);
        public bool ReviewExists(int idReview);

    }

}
