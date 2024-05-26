public class SimpleGoal : Goal
    {
        protected bool _isComplete;

        public SimpleGoal(string name, string description, string points)
            : base(name, description, points)
        {
            _isComplete = false;
        }

        public override void RecordEvent(ref int score)
        {
            _isComplete = true;
            score += GetPoints();
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
        }

        public void SetCompletion(bool isComplete)
        {
            _isComplete = isComplete;
        }
    }