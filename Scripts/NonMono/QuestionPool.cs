
using System.Collections.Generic;

public class QuestionPool
{
    public string Question { get; set; }
    public int Answer { get; set; }
    public string[] Choices { get; set; }

    public bool Done { get; set; }
    public bool Required { get; set; }
    public int Tries { get; set; }
    public List<int> PlayerAnswers { get; set; }
    public float Timer { get; set; }
    public float Interval { get; set; }
    public int Grade { get; set; }
}
