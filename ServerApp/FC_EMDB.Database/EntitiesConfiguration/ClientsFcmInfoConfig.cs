using System;
using System.Collections.Generic;
using System.Text;
using FC_EMDB.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC_EMDB.Database.EntitiesConfiguration
{
    class ClientsFcmInfoConfig : IEntityTypeConfiguration<ClientsFcmInfo>
    {
        public void Configure(EntityTypeBuilder<ClientsFcmInfo> builder)
        {
            builder.HasKey(cf => new { cf.ClientId, cf.FcmInfoId });

            builder.HasOne(cf => cf.Client).
                WithMany(cli => cli.ClientsFcmInfos).
                HasForeignKey(cf => cf.ClientId);//связь с  client

            builder.HasOne(cf => cf.FcmInfo).
                WithMany(fcmInfo => fcmInfo.ClientsFcmInfos).
                HasForeignKey(cf => cf.FcmInfoId);//связь с  FcmInfo
        }
    }
}
