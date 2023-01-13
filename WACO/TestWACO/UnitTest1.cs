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
            int ci = 51182703;
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            Associate u = new Associate(ci, "Leonardo", "Da Vinci", 20);
            wcs.Register(u);
            Assert.AreEqual(wcs.associates.Contains(u), true);
        }
        [TestMethod]
        public void RepeatedUserRegistrationException()
        {
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            Associate u = new Associate(6612, "Leonardo", "Da Vinci", 20);
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
            int ci = 51182703;
            Associate u = new Associate(ci, "Leonardo", "Da Vinci", 20);
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            Lecture lastLecture = new Lecture(ci, 35, "January", 2023, 1, 12, 11, 6);
            wcs.RegisterNewLecture(lastLecture);
            Associate aux = wcs.associates.Find(e => e.Ci == ci);
            Assert.AreEqual(aux.LastLecture, 35);
        }
        [TestMethod]

        public void NewLectureCantBeLowerThanPreviousTest()
        {
            int ci = 51182703;
            Associate u = new Associate(ci, "Leonardo", "Da Vinci", 20);
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            Lecture lastLecture = new Lecture(ci, 19, "January", 2023, 1, 12, 11, 6);
            string message = string.Empty;
            try
            {
                wcs.RegisterNewLecture(lastLecture);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual(message, "New Lecture cant be lower than previous one");
        }

        [TestMethod]

        public void TruncateToIntWhenLectureIsDecimalTest()
        {
            int ci = 51182703;
            Associate u = new Associate(ci, "Leonardo", "Da Vinci", 20);
            WaterConsumptionSystem wcs = new WaterConsumptionSystem();
            wcs.Register(u);
            double lastLectureAmount = 23.1;
            Lecture lastLecture = new Lecture(ci, lastLectureAmount, "January", 2023, 1, 12, 11, 6);
            wcs.RegisterNewLecture(lastLecture);
            Console.WriteLine(wcs.lectures.Find(e => e.UserCi == ci).AmountLectured);
            Assert.AreEqual(23, wcs.SearchByPeriodAndCi(ci,"January").AmountLectured );
        }
       
    }
}
