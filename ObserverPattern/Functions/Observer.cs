using ObserverPattern.Models;
using ObserverPattern.Repository;

namespace ObserverPattern.Functions
{
    public class Observer : IObserver<CustomerMast>
    {
        private readonly Subject subject;
        public void OnCompleted()
        {
            Console.WriteLine("Completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Error");
        }

        public void OnNext(CustomerMast value)
        {
            
            MainRepo m1=new MainRepo(new InfinityDbContext());
            m1.InsertInSMSLog(value);
        }
    }
}
