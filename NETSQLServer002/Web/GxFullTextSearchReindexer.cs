using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class GxFullTextSearchReindexer
   {
      public static int Reindex( IGxContext context )
      {
         GxSilentTrnSdt obj;
         IGxSilentTrn trn;
         bool result;
         obj = new SdtEspectaculo(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtInvitacion(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtLugar(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtEvento(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtSector(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtPais(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtTipoEspectaculo(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtVenta(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         return 1 ;
      }

   }

}
