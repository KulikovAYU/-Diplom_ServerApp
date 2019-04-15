namespace FC_EMDB.Entities.Entities
{
  public  class ClientsFcmInfo
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int FcmInfoId { get; set; }
        public FcmInfo FcmInfo { get; set; }
    }
}
