public class ChecklistGoal : Goal
{
        protected int _amountCompleted;
        protected int _target;
        protected string _bonus;

        public ChecklistGoal(string shortName, string description, string points, int target, string bonus)
            : base(shortName, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = 0;
        }

        public override void RecordEvent(ref int score)
        {
            _amountCompleted++;
            score += GetPoints();
            if (_amountCompleted >= _target)
            {
                score += int.Parse(_bonus);
                _amountCompleted = 0; // reset for next cycle if needed
            }
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            return $"{(IsComplete() ? "[X]" : "[ ]")} {_shortName}: {_description} - Completed {_amountCompleted}/{_target} times";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
        }

        public void SetAmountCompleted(int amountCompleted)
        {
            _amountCompleted = amountCompleted;
        }
}