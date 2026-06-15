namespace SimplifyingConditionalExpressions.ReplaceNestedConditional
{
    /*
     * Problem:
     * You have a group of nested conditionals and it’s hard to determine the normal flow of code execution.
     * 
     * Solution
     * Isolate all special checks and edge cases into separate clauses and place them before the main checks. Ideally, you should have a “flat” list of conditionals, one after the other.
     * 
    */
    public class Payment
    {
        private bool IsDead;
        private bool IsSeparated;
        private bool IsRetired;
        private double Value;

        public Payment(bool isDead,
            bool isSeparated,
            bool isRetired,
            double value) 
        {
            IsDead = isDead;
            IsSeparated = isSeparated;
            IsRetired = isRetired;
            Value = value;
        }

        public double GetPayAmount()
        {
            if (this.IsDead)
            {
                return DeadAmount();
            }
            if (this.IsSeparated)
            {
                return SeparatedAmount();
            }
            if (this.IsRetired)
            {
                return RetiredAmount();
            }

            return NormalPayAmount();
        }

        private double SeparatedAmount() => 22;

        private double RetiredAmount() => this.Value * 2;

        private double NormalPayAmount() => this.Value;

        private double DeadAmount() => this.Value * 0.5;
    }
}
