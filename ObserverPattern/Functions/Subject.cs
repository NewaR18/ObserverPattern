
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObserverPattern.Models;
using ObserverPattern.Repository;

namespace ObserverPattern.Functions
{
    public class Subject : IObservable<CustomerMast>, IDisposable
    {
        private CustomerMast customer;
        private List<IObserver<CustomerMast>> observers=new List<IObserver<CustomerMast>>();
        public Subject(CustomerMast _customer) { 
            customer = _customer;
        }
        public void Dispose()
        {
            observers.Clear();
        }

        public IDisposable Subscribe(IObserver<CustomerMast> observer)
        {
            this.observers.Add(observer);
            //observer.OnNext(customer);
            return this;
        }
        public void SearchForChange()
        {
            InfinityDbContext _context = new InfinityDbContext();
            CustomerMast m2= _context.CustomerMasts.Where(st => ((st.BirthDate.Value.Month != this.customer.BirthDate.Value.Month || st.BirthDate.Value.Day != this.customer.BirthDate.Value.Day) ||(st.FirstName!=this.customer.FirstName || st.MiddleName != this.customer.MiddleName || st.LastName !=this.customer.LastName)) && st.TranId == this.customer.TranId).FirstOrDefault();
            if(m2 != null)
            {
                this.customer.BirthDate = m2.BirthDate;
                this.customer.FirstName = m2.FirstName;
                this.customer.MiddleName = m2.MiddleName;
                this.customer.LastName = m2.LastName;
                foreach (var observer in observers)
                {
                    observer.OnNext(m2);
                }
            }
        }
    }
}
