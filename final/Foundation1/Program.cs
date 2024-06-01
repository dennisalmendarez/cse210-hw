using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Playing Soccer", "Juan Fortich", 500);
        Video video2 = new Video("Cooking", "Stela", 600);
        Video video3 = new Video("Runing in the rain", "Frankstain", 300);
        
        video1.AddComment(new Comment("User1", "Great video!"));
        video1.AddComment(new Comment("User2", "Nice game, I want to play now."));
        video1.AddComment(new Comment("User3", "It was a red card!."));

        video2.AddComment(new Comment("User4", "Nice tutorial."));
        video2.AddComment(new Comment("User5", "I learned a lot."));
        video2.AddComment(new Comment("User6", "Keep it up!"));

        video3.AddComment(new Comment("User7", "You going to cacth a cold."));
        video3.AddComment(new Comment("User8", "I want to be there."));
        video3.AddComment(new Comment("User9", "Why raining thought?"));

        List<Video> videos = new List<Video>{video1, video2, video3};

        foreach (var video in videos){
            Console.WriteLine("Tittle: {0}", video._tittle);
            Console.WriteLine("Author: {0}", video._author);
            Console.WriteLine("Durantion: {0}", video._length);
            Console.WriteLine("Number of comments: {0}", video.GetNumberOfComments());
            Console.WriteLine();

            var comments = video.GetComments();

            foreach (var comment in comments){
                Console.WriteLine($"- {comment._name} - {comment._comments}");
            }
            Console.WriteLine();
        }
    }
}