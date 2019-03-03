using System;

namespace FC_EMDB
{

    public class Training
    {
        public int mnTrtainingId { get; set; } //id тренировки

        public DateTime mStartTime { get; set; }//время начала

        public DateTime mEndDime { get; set; }//время окончания тренировки

        public string mTrainingName { get; set; }//название тренировки

        public bool mbIsFinished { get; set; }//признак законченной тренировки

        public string mGymName { get; set; } //название зала

        public string mLevelName { get; set; }//уровень

        public string mCoachName { get; set; }//имя инструктора

        public string mDescription { get; set; }// описание

        public bool mbIsReplaced { get; set; }//заменена ли тренировка

        public bool mbIsMustPay { get; set; }//платная

        public string mProgramType { get; set; }//тип программы

        public bool mbIspopular { get; set; }//признак популярности

        public int mnplacesCount { get; set; }//количество записей (вместимость)

        public int mnFreePlacesCount { get; set; }//количество свободных мест

        public int mnBusyPlacesCount { get; set; }// количество занятых мест

    }

}
