using System;
using System.Collections.Generic;

namespace YouTubeVideoTracker
{
    public class Comment
    {
        public string CommenterName { get; set; }
        public string CommentText { get; set; }

        public Comment(string commenterName, string commentText)
        {
            CommenterName = commenterName;
            CommentText = commentText;
        }
    }

    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        public List<Comment> Comments { get; set; }

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return Comments.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            // Video 1
            Video video1 = new Video("How to Cook Pasta", "Chef Mario", 300);
            video1.AddComment(new Comment("Alice", "This was super helpful!"));
            video1.AddComment(new Comment("Bob", "Tried it and loved it."));
            video1.AddComment(new Comment("Charlie", "Easy and quick!"));
            videos.Add(video1);

            // Video 2
            Video video2 = new Video("Top 10 Coding Tips", "Tech Guru", 480);
            video2.AddComment(new Comment("Dave", "Tip #3 changed my life."));
            video2.AddComment(new Comment("Emma", "Clear and concise."));
            video2.AddComment(new Comment("Frank", "Subscribed!"));
            videos.Add(video2);

            // Video 3
            Video video3 = new Video("Best Hiking Trails", "Nature Now", 720);
            video3.AddComment(new Comment("Gina", "Adding these to my bucket list."));
            video3.AddComment(new Comment("Henry", "Beautiful shots!"));
            video3.AddComment(new Comment("Ivy", "Love the nature sounds."));
            videos.Add(video3);

            // Video 4
            Video video4 = new Video("Learn Guitar in 5 Minutes", "Music Master", 360);
            video4.AddComment(new Comment("Jake", "I learned so much!"));
            video4.AddComment(new Comment("Karen", "Perfect for beginners."));
            video4.AddComment(new Comment("Leo", "Great tutorial."));
            videos.Add(video4);

            // Display all videos and their comments
            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length (seconds): {video.LengthInSeconds}");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.Comments)
                {
                    Console.WriteLine($" - {comment.CommenterName}: {comment.CommentText}");
                }
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}