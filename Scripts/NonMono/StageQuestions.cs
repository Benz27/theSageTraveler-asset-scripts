
using System.Collections.Generic;


public class StageQuestions 
{
    public List<Chapter> Chapter { get; set; }
}

public class Chapter
{
    public List<PuzzleQuestion> QuestionPool { get; set; }
}

public class PuzzleQuestion
{
    public string Question { get; set; }
    public string[] Choices { get; set; }
    public int Answer { get; set; }
}
