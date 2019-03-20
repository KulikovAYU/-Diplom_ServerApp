using FC_EMDB.Entities.Entities;

namespace FC_EMDB.Entities
{


    public static class ExtentionsEntityMethods
    {
        #region TrainingData
        public static bool IsNotNull(this TrainingData td)
        {
            return td != null;
        }

        public static bool IsNull(this TrainingData td)
        {
            return td == null;
        }
        #endregion

        #region Training
        public static bool IsNotNull(this ProgramType pt)
        {
            return pt != null;
        }
        public static bool IsNull(this ProgramType pt)
        {
            return pt == null;
        }
        #endregion

        #region Gym
        public static bool IsNotNull(this Gym gym)
        {
            return gym != null;
        }
        public static bool IsNull(this Gym gym)
        {
            return gym == null;
        }
        #endregion

        #region CoachTraining
        public static bool IsNotNull(this CoachTraining ct)
        {
            return ct != null;
        }
        public static bool IsNull(this CoachTraining ct)
        {
            return ct == null;
        }
        #endregion


        #region Employee
        public static bool IsNotNull(this Employee empl)
        {
            return empl != null;
        }
        public static bool IsNull(this Employee empl)
        {
            return empl == null;
        }
        #endregion

        #region TrainingLevel
        public static bool IsNotNull(this TrainingLevel tl)
        {
            return tl != null;
        }
        public static bool IsNull(this TrainingLevel tl)
        {
            return tl == null;
        }
        #endregion


        //#region Training
        //public static bool IsNotNull(this Training tr)
        //{
        //    return tr != null;
        //}
        //public static bool IsNotNull(this Client cl)
        //{
        //    return cl != null;
        //}
        //#endregion





    }



}
