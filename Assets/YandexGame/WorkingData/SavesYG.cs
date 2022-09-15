
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Ваши сохранения
        public bool isAskedReview = false;
        public int money = 0;
        public bool[] ballOpen = new bool[36]; // добавить размерность массива
        public int ballIndex; //номер шарика
        public int LevelIndexLoad = 2; //какую сцену нужно загрузить
        public int maxLevel; //сколько всего уровней пройдено
    }
}
