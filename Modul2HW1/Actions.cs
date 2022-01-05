using Modul2HW1.Interfaces;

namespace Modul2HW1
{
    public class Actions : IActions
    {
        private readonly Logger _logger;

        public Actions()
        {
            _logger = Logger.Instance;
        }

        public Result Method_1()
        {
            _logger.LogInfo($"Start method: {nameof(Method_1)}");
            return new Result() { Status = true };
        }

        public Result Method_2()
        {
            _logger.LogWarning($"Skipped logic in method: {nameof(Method_2)}");
            return new Result() { Status = true };
        }

        public Result Method_3()
        {
            return new Result() { ErrorMessage = "I broke a logic" };
        }
    }
}
