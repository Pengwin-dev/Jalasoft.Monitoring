using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;

namespace WACO
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserRegistrationTest()
        {
            Associate u = new Associate(6612, "Leonardo", "Da Vinci", new Lecture(20));
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            Assert.AreEqual(wcs.users.Contains(u), true);
        }
        [TestMethod]
        public void RepeatedUserRegistrationException()
        {
            Associate u = new Associate(6612, "Leonardo", "Da Vinci", new Lecture(20));

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
            Associate u = new Associate(6612, "Leonardo", "Da Vinci", new Lecture(20, "December", new DateTime(2022, 12, 12, 11, 6, 32)));
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            Lecture lastLecture = new Lecture(35,"January", new DateTime(2023, 1, 12, 11, 6, 32));
            wcs.RegisterNewLecture(6612, lastLecture);
            Associate aux = wcs.users.Find(e => e.Ci == 6612);
            Assert.AreEqual(aux.LastLecture.AmountLectured, 35) ;
        }
        [TestMethod]

        public void NewLectureCantBeLowerThanPreviousTest()
        {
            Associate u = new Associate(6612, "Leonardo", "Da Vinci", new Lecture(20, "December", new DateTime(2022, 12, 12, 11, 6, 32)));
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            Lecture lastLecture = new Lecture(15, "January", new DateTime(2023, 1, 12, 11, 6, 32));
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
            Associate u = new Associate(6612, "Leonardo", "Da Vinci", new Lecture(20, "December", new DateTime(2022, 12, 12, 11, 6, 32)));
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            double lastLectureAmount = 23.1;
            Lecture lastLecture = new Lecture(lastLectureAmount, "January", new DateTime(2023, 1, 12, 11, 6, 32));
            Associate aux = wcs.users.Find(e => e.Ci == 6612);
            wcs.RegisterNewLecture(6612, lastLecture);
            Assert.AreEqual(aux.LastLecture.AmountLectured, 23);
        }

    }
}
