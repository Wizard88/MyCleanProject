namespace ViewAbstraction
{
    public interface IMainView
    {
        event TabSelectDelegate TabSelected;
        event CourseDelegate CourseSelected;
        event StudentDelegate StudentSelected;

        event ButtonDelegate CreateAction;
        event ButtonDelegate UpdateAction;
        event ButtonDelegate DeleteAction;
    }
}
