namespace Logic
{
    public class AvgScore
    {
        public float Average { get; private set; }
        private EducationalElement element;

        public AvgScore(float average, EducationalElement ee)
        {
            Average = average;
            element = ee;
        }

        public override string ToString()
        {
            return $"{element.Name} : {Average:0.00} / 20";
        }
    }
}