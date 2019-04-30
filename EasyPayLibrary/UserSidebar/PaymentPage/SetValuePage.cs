namespace EasyPayLibrary
{
    public class SetValuePage:BasePageObject
    {
        WebElementWrapper fieldNewCurrentValue;
        WebElementWrapper btnApply;

        public override void Init(DriverWrapper driver)
        {
            fieldNewCurrentValue = driver.GetByXpath("//input[@id='newCurrentValue']");
            btnApply = driver.GetByXpath("//button[@class='btn btn-primary js-apply']");
            base.Init(driver);
        }
        public void SetFieldNewCurrentValue(float Value)
        {
            fieldNewCurrentValue.SendText(Value.ToString());
        }

        public void ClickSetApply()
        {
            btnApply.ClickOnIt();
        }

        public UtilityDetailsPage SetValue(float value)
        {
            SetFieldNewCurrentValue(value);
            ClickSetApply();
            return GetPOM<UtilityDetailsPage>(driver);
        }

    }
}