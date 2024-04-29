using System.Collections.Generic;

namespace Constants
{
    public static class Consts
    {
        public static readonly Dictionary<SceneNames, string> Scenes = new()
        {
            [SceneNames.Title] = "TitleScene",
            [SceneNames.StageSelect] = "StageSelectScene",
            [SceneNames.Tutorial] = "TutorialStage",
            [SceneNames.Stage1] = "Stage1",
            [SceneNames.Stage2] = "Stage2",
            [SceneNames.Stage3] = "Stage3",
            [SceneNames.GameClear] = "ResultScene",
            [SceneNames.GameOver] = "GameOverScene",
        };
    }

    public enum SceneNames
    {
        Title,
        StageSelect,
        Tutorial,
        Stage1,
        Stage2,
        Stage3,
        GameClear,
        GameOver,
    }
}
