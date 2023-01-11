namespace WACO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserRegistrationTest()
        {
            User u = new User("Leonardo", "Da Vinci", 20);
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            Assert.AreEqual(wcs.users.Contains(u), true);
        }
        [TestMethod]
        public void RepeatedUserRegistrationException()
        {
            User u = new User("Leonardo", "Da Vinci", 20);
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            string message = string.Empty;
            
            try
            {
                wcs.Register(u);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("There's a duplicate on the register", message);
        }
    }
}