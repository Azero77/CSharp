namespace CostumAttributes
{
    internal class SkillAttribute : Attribute
    {
        public int MinValue { get;private set; }
        public int MaxValue { get; private set; }
        public string NameOfSkill { get; private set; }

//you can specify the members able to set this attribute
        public SkillAttribute(string nameOfSkill ,int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            NameOfSkill = nameOfSkill;
        }

        public bool IsValid(int value)
        {
            return value >= MinValue && value <= MaxValue;
        }
    }
}