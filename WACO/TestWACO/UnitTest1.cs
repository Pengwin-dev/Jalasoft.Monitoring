using System.Runtime.Intrinsics.X86;

namespace WACO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserRegistrationTest()
        {
            User u = new User(6612,"Leonardo", "Da Vinci", 20);
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            Assert.AreEqual(wcs.users.Contains(u), true);
        }
        [TestMethod]
        public void RepeatedUserRegistrationException()
        {
            User u = new User(6612,"Leonardo", "Da Vinci", 20);
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

        [TestMethod]
        
        public void LectureRegistrationTest()
        {
            User u = new User(6612, "Leonardo", "Da Vinci", 20);
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            int lastLecture = 35;
            wcs.RegisterNewLecture(6612, lastLecture);
            User aux = wcs.users.Find(e => e.Ci == 6612);
            Assert.AreEqual(aux.LitersConsumed, 35) ;
        }
        [TestMethod]

        public void NewLectureCantBeLowerThanPreviousTest()
        {
            User u = new User(6612, "Leonardo", "Da Vinci", 20);
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            int lastLecture = 15;
            string message = string.Empty;
            try
            {
                wcs.RegisterNewLecture(6612, lastLecture);
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual(message, "New Lecture cant be lower than previous one");
        }

        [TestMethod]

        public void TruncateToIntWhenLectureIsDecimalTest()
        {
            User u = new User(6612, "Leonardo", "Da Vinci", 20);
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            double lastLecture = 23.1;
            User aux = wcs.users.Find(e => e.Ci == 6612);
            wcs.RegisterNewLecture(6612, lastLecture);
            Assert.AreEqual(aux.LitersConsumed, 23);
        }

    }
}
