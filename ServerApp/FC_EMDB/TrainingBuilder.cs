using System;
using System.Collections.Generic;
using System.Text;

namespace FC_EMDB
{
    public class TrainingBuilder
    {
        public bool mbIsReplaced { get; private set; } = false; //заменена ли тренировка

        // protected boolean mbIsMustPay = false; //платная
        public bool mbIsNewTraining { get; private set; } = false; // признак новой тренировки
        public bool mbIsFinished { get; private set; } = false; //признак законченной тренировки
        public DateTime mStartTime { get; private set; } //время начала
        public DateTime mEndDime { get; private set; } //время окончания тренировки
        public string mTrainingName { get; private set; } //название тренировки
        public string mGymName { get; private set; } //название зала
        public string mLevelName { get; private set; } //уровень
        public string mDescription { get; private set; } //описание тренировки
        public string mProgramType { get; private set; } //тип программы
        public bool mbIspopular { get; private set; } = false; //признак популярности
        public bool mbIsMustPay { get; private set; } = false; //платная

        public int mnFreePlacesCount { get; private set; } //количество свободных мест
        public int mnplacesCount { get; private set; } //количество записей (вместимость)
        public int mnBusyPlacesCount { get; private set; } // количество занятых мест

        //вспомогательные поля
        public String mCoachName { get; private set; } //имя инструктора
        public String mCoachFamily { get; private set; } //фамилия инструктора


        public TrainingBuilder Replaced()
        {
            this.mbIsReplaced = true;
            return this;
        }

        public TrainingBuilder Capacity(int nplacesCount)
        {
            mnplacesCount = nplacesCount;
            return this;
        }

        public TrainingBuilder FreePlacesCount()
        {
            mnFreePlacesCount = mnplacesCount - mnBusyPlacesCount;
            return this;
        }

        public TrainingBuilder BusyPlacesCount(int nBusyPlacesCount)
        {
            mnBusyPlacesCount = nBusyPlacesCount;
            return this;
        }


        //        public TrainingBuilder MustPay() {
        //            this.mbIsMustPay = true;
        //            return this;
        //        }

        public TrainingBuilder StartTime(DateTime time)
        {
            this.mStartTime = time;
            return this;
        }

        public TrainingBuilder EndTime(DateTime time)
        {
            this.mEndDime = time;
            return this;
        }

        public TrainingBuilder Name(String trainingName)
        {
            this.mTrainingName = trainingName;
            return this;
        }

        public TrainingBuilder GymName(String gymName)
        {
            this.mGymName = gymName;
            return this;
        }

        public TrainingBuilder LevelName(String levelName)
        {
            this.mLevelName = levelName;
            return this;
        }

        public TrainingBuilder CoachName(String coachName)
        {
            this.mCoachName = coachName;
            return this;
        }

        public TrainingBuilder CoachFamily(String coachFamily)
        {
            this.mCoachFamily = coachFamily;
            return this;
        }

        public TrainingBuilder Description(String desc)
        {
            this.mDescription = desc;
            return this;
        }

        public TrainingBuilder IsMustPay()
        {
            this.mbIsMustPay = true;
            return this;
        }

        public TrainingBuilder IsNewTraining()
        {
            this.mbIsNewTraining = true;
            return this;
        }

        public TrainingBuilder ProgramType(String programType)
        {
            this.mProgramType = programType;
            return this;
        }

        private TrainingBuilder IsFinished()
        {
            mbIsFinished = true;
            return this;
        }

        public TrainingBuilder IsPopular()
        {
            mbIspopular = true; //признак популярности
            return this;
        }

    
        public Training Build()
        {
            return new Training(this);
        }
    }
}
