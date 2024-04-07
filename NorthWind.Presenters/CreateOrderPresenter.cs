
namespace NorthWind.Presenters
{
    public class CreateOrderPresenter : IPresenter<int, string>
    {
        public CreateOrderPresenter()
        {

        }

        public string Content { get; private set; }

        public void Handle(int response)
        {
            Content = $"Order ID: {response}";
        }
    }
}