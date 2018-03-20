#pragma warning disable 0649

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HoganLovells.Nbi
{
    public partial class RequestSubmit
    {

        public void Comment ()
        {
            commentTextArea.Set(DataManager.GetParamater("Comment", DataGenerator.Yes));
        }

        public void Proceed()
        {
            proceedButton.Click2();
        }

    }
}
