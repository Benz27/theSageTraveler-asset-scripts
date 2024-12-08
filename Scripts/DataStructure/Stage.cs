using System.Collections.Generic;

public class Stage 
{
    public int StageLevel { get; set; }
    public string StageName { get; set; }
    public bool UnLocked { get; set; }
    public bool ShowCutScene { get; set; }
    public StageRecordStack StageRecordStack { get; set; }
}

public class StageRecordStack
{
    //public StageRecord[] StageRecord { get; set; }
    public List<StageRecord> StageRecord { get; set; }
}

public class StageRecord
{


    public int TotalGrade { get; set; }
    public List<QuestionPool> QuestionPool { get; set; }

    //public int TotalGrade { get; set; }
    //public List<PuzzleInfo> PuzzleInfo { get; set; }
    //public PuzzleInfo[] PuzzleInfo { get; set; }
}


public class PuzzleInfo
{
    public int PuzzleID { get; set; }
    public QuestionPool QuestionPool { get; set; }
}








