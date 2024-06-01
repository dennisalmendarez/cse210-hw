using System;

public class Video{
    public string _tittle;
    public string _author;
    public int _length;
    public List<Comment> _comments;

    public Video(string tittle, string author, int length){
        _tittle = tittle;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comments){
        _comments.Add(comments);
    }

    public int GetNumberOfComments(){
        return _comments.Count;
    }

    public List<Comment> GetComments(){
        return _comments;
    }
}