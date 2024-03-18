namespace HundeProjekt.Services
{
    public class CourseViewCounter : ICourseViewCounter
    {
        private int _viewCourseCounter;

        public void IncrementCounter()
        {
            _viewCourseCounter++;
        }

        public int GetCounter()
        {
            return _viewCourseCounter;
        }
    }
}
