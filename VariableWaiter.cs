namespace Final_app
{
    using System;
    using System.Threading.Tasks;

    public class VariableWaiter
    {
        private TaskCompletionSource<bool> _tcs = new TaskCompletionSource<bool>();

        public async Task WaitForConditionAsync()
        {
            await _tcs.Task;
        }

        public void SetCondition()
        {
            _tcs.TrySetResult(true);
        }
    }
}