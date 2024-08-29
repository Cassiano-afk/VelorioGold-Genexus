using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class obitosconversion : GXProcedure
   {
      public obitosconversion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Design\\GoldLegacy", false);
      }

      public obitosconversion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor OBITOSCONV2 */
         pr_datastore1.execute(0);
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            A54Seq = OBITOSCONV2_A54Seq[0];
            n54Seq = OBITOSCONV2_n54Seq[0];
            A53UsouCremacao = OBITOSCONV2_A53UsouCremacao[0];
            n53UsouCremacao = OBITOSCONV2_n53UsouCremacao[0];
            A52Matricula = OBITOSCONV2_A52Matricula[0];
            n52Matricula = OBITOSCONV2_n52Matricula[0];
            A51TaxaSepultamento = OBITOSCONV2_A51TaxaSepultamento[0];
            n51TaxaSepultamento = OBITOSCONV2_n51TaxaSepultamento[0];
            A50TaxaCapelaAux = OBITOSCONV2_A50TaxaCapelaAux[0];
            n50TaxaCapelaAux = OBITOSCONV2_n50TaxaCapelaAux[0];
            A49DoencasConhecidas = OBITOSCONV2_A49DoencasConhecidas[0];
            n49DoencasConhecidas = OBITOSCONV2_n49DoencasConhecidas[0];
            A48ViciosEspecificar = OBITOSCONV2_A48ViciosEspecificar[0];
            n48ViciosEspecificar = OBITOSCONV2_n48ViciosEspecificar[0];
            A47ViciosHabituais = OBITOSCONV2_A47ViciosHabituais[0];
            n47ViciosHabituais = OBITOSCONV2_n47ViciosHabituais[0];
            A46RelatoObito = OBITOSCONV2_A46RelatoObito[0];
            n46RelatoObito = OBITOSCONV2_n46RelatoObito[0];
            A45RegistroUnesp = OBITOSCONV2_A45RegistroUnesp[0];
            n45RegistroUnesp = OBITOSCONV2_n45RegistroUnesp[0];
            A44PacienteUnesp = OBITOSCONV2_A44PacienteUnesp[0];
            n44PacienteUnesp = OBITOSCONV2_n44PacienteUnesp[0];
            A43PercentualCobertura = OBITOSCONV2_A43PercentualCobertura[0];
            n43PercentualCobertura = OBITOSCONV2_n43PercentualCobertura[0];
            A42EmCarencia = OBITOSCONV2_A42EmCarencia[0];
            n42EmCarencia = OBITOSCONV2_n42EmCarencia[0];
            A41ObservacaoAux = OBITOSCONV2_A41ObservacaoAux[0];
            n41ObservacaoAux = OBITOSCONV2_n41ObservacaoAux[0];
            A40DataPagtoAux = OBITOSCONV2_A40DataPagtoAux[0];
            n40DataPagtoAux = OBITOSCONV2_n40DataPagtoAux[0];
            A39ValorAux = OBITOSCONV2_A39ValorAux[0];
            n39ValorAux = OBITOSCONV2_n39ValorAux[0];
            A38NumControleAux = OBITOSCONV2_A38NumControleAux[0];
            n38NumControleAux = OBITOSCONV2_n38NumControleAux[0];
            A37UsuUpdate = OBITOSCONV2_A37UsuUpdate[0];
            n37UsuUpdate = OBITOSCONV2_n37UsuUpdate[0];
            A36DataUpdate = OBITOSCONV2_A36DataUpdate[0];
            n36DataUpdate = OBITOSCONV2_n36DataUpdate[0];
            A35UsuInsert = OBITOSCONV2_A35UsuInsert[0];
            n35UsuInsert = OBITOSCONV2_n35UsuInsert[0];
            A34DataInsert = OBITOSCONV2_A34DataInsert[0];
            n34DataInsert = OBITOSCONV2_n34DataInsert[0];
            A33EstCivilContratanteAux = OBITOSCONV2_A33EstCivilContratanteAux[0];
            n33EstCivilContratanteAux = OBITOSCONV2_n33EstCivilContratanteAux[0];
            A32CPFContratanteAux = OBITOSCONV2_A32CPFContratanteAux[0];
            n32CPFContratanteAux = OBITOSCONV2_n32CPFContratanteAux[0];
            A31RGContratanteAux = OBITOSCONV2_A31RGContratanteAux[0];
            n31RGContratanteAux = OBITOSCONV2_n31RGContratanteAux[0];
            A30CidadeContratanteAux = OBITOSCONV2_A30CidadeContratanteAux[0];
            n30CidadeContratanteAux = OBITOSCONV2_n30CidadeContratanteAux[0];
            A29EndContratanteAux = OBITOSCONV2_A29EndContratanteAux[0];
            n29EndContratanteAux = OBITOSCONV2_n29EndContratanteAux[0];
            A28NomeContratanteAux = OBITOSCONV2_A28NomeContratanteAux[0];
            n28NomeContratanteAux = OBITOSCONV2_n28NomeContratanteAux[0];
            A27DatasolicitacaoAux = OBITOSCONV2_A27DatasolicitacaoAux[0];
            n27DatasolicitacaoAux = OBITOSCONV2_n27DatasolicitacaoAux[0];
            A26HoraSepultamento = OBITOSCONV2_A26HoraSepultamento[0];
            n26HoraSepultamento = OBITOSCONV2_n26HoraSepultamento[0];
            A25LocalFalecimento = OBITOSCONV2_A25LocalFalecimento[0];
            n25LocalFalecimento = OBITOSCONV2_n25LocalFalecimento[0];
            A24CidadeFalecimento = OBITOSCONV2_A24CidadeFalecimento[0];
            n24CidadeFalecimento = OBITOSCONV2_n24CidadeFalecimento[0];
            A23horafalecimento = OBITOSCONV2_A23horafalecimento[0];
            n23horafalecimento = OBITOSCONV2_n23horafalecimento[0];
            A22EnderecoFalecido = OBITOSCONV2_A22EnderecoFalecido[0];
            n22EnderecoFalecido = OBITOSCONV2_n22EnderecoFalecido[0];
            A21Capela = OBITOSCONV2_A21Capela[0];
            n21Capela = OBITOSCONV2_n21Capela[0];
            A20SeqDependente = OBITOSCONV2_A20SeqDependente[0];
            n20SeqDependente = OBITOSCONV2_n20SeqDependente[0];
            A19Lote = OBITOSCONV2_A19Lote[0];
            n19Lote = OBITOSCONV2_n19Lote[0];
            A18Quadra = OBITOSCONV2_A18Quadra[0];
            n18Quadra = OBITOSCONV2_n18Quadra[0];
            A17Jazigo = OBITOSCONV2_A17Jazigo[0];
            n17Jazigo = OBITOSCONV2_n17Jazigo[0];
            A16Cemiterio = OBITOSCONV2_A16Cemiterio[0];
            n16Cemiterio = OBITOSCONV2_n16Cemiterio[0];
            A15Parentesco = OBITOSCONV2_A15Parentesco[0];
            n15Parentesco = OBITOSCONV2_n15Parentesco[0];
            A14Observacao = OBITOSCONV2_A14Observacao[0];
            n14Observacao = OBITOSCONV2_n14Observacao[0];
            A13Funeraria = OBITOSCONV2_A13Funeraria[0];
            n13Funeraria = OBITOSCONV2_n13Funeraria[0];
            A12NFValor = OBITOSCONV2_A12NFValor[0];
            n12NFValor = OBITOSCONV2_n12NFValor[0];
            A11NFNumero = OBITOSCONV2_A11NFNumero[0];
            n11NFNumero = OBITOSCONV2_n11NFNumero[0];
            A10NumeroObito = OBITOSCONV2_A10NumeroObito[0];
            n10NumeroObito = OBITOSCONV2_n10NumeroObito[0];
            A7Vencimento = OBITOSCONV2_A7Vencimento[0];
            n7Vencimento = OBITOSCONV2_n7Vencimento[0];
            A6Valor = OBITOSCONV2_A6Valor[0];
            n6Valor = OBITOSCONV2_n6Valor[0];
            A5Numero = OBITOSCONV2_A5Numero[0];
            n5Numero = OBITOSCONV2_n5Numero[0];
            A4Referencia = OBITOSCONV2_A4Referencia[0];
            n4Referencia = OBITOSCONV2_n4Referencia[0];
            A3Grupo = OBITOSCONV2_A3Grupo[0];
            n3Grupo = OBITOSCONV2_n3Grupo[0];
            A2Nome = OBITOSCONV2_A2Nome[0];
            A1Inscricao = OBITOSCONV2_A1Inscricao[0];
            A8Nascimento = OBITOSCONV2_A8Nascimento[0];
            n8Nascimento = OBITOSCONV2_n8Nascimento[0];
            A9Falecimento = OBITOSCONV2_A9Falecimento[0];
            n9Falecimento = OBITOSCONV2_n9Falecimento[0];
            A40001GXC2 = DateTimeUtil.ResetTime( A9Falecimento);
            A40000GXC1 = DateTimeUtil.ResetTime( A8Nascimento);
            /*
               INSERT RECORD ON TABLE GXA0001

            */
            AV2Inscricao = A1Inscricao;
            AV3Nome = A2Nome;
            if ( OBITOSCONV2_n3Grupo[0] )
            {
               AV4Grupo = "";
               nV4Grupo = false;
               nV4Grupo = true;
            }
            else
            {
               AV4Grupo = A3Grupo;
               nV4Grupo = false;
            }
            if ( OBITOSCONV2_n4Referencia[0] )
            {
               AV5Referencia = "";
               nV5Referencia = false;
               nV5Referencia = true;
            }
            else
            {
               AV5Referencia = A4Referencia;
               nV5Referencia = false;
            }
            if ( OBITOSCONV2_n5Numero[0] )
            {
               AV6Numero = 0;
               nV6Numero = false;
               nV6Numero = true;
            }
            else
            {
               AV6Numero = A5Numero;
               nV6Numero = false;
            }
            if ( OBITOSCONV2_n6Valor[0] )
            {
               AV7Valor = 0;
               nV7Valor = false;
               nV7Valor = true;
            }
            else
            {
               AV7Valor = A6Valor;
               nV7Valor = false;
            }
            if ( OBITOSCONV2_n7Vencimento[0] )
            {
               AV8Vencimento = (DateTime)(DateTime.MinValue);
               nV8Vencimento = false;
               nV8Vencimento = true;
            }
            else
            {
               AV8Vencimento = A7Vencimento;
               nV8Vencimento = false;
            }
            if ( OBITOSCONV2_n8Nascimento[0] )
            {
               AV9Nascimento = DateTime.MinValue;
               nV9Nascimento = false;
               nV9Nascimento = true;
            }
            else
            {
               AV9Nascimento = A40000GXC1;
               nV9Nascimento = false;
            }
            if ( OBITOSCONV2_n9Falecimento[0] )
            {
               AV10Falecimento = DateTime.MinValue;
               nV10Falecimento = false;
               nV10Falecimento = true;
            }
            else
            {
               AV10Falecimento = A40001GXC2;
               nV10Falecimento = false;
            }
            if ( OBITOSCONV2_n10NumeroObito[0] )
            {
               AV11NumeroObito = "";
               nV11NumeroObito = false;
               nV11NumeroObito = true;
            }
            else
            {
               AV11NumeroObito = A10NumeroObito;
               nV11NumeroObito = false;
            }
            if ( OBITOSCONV2_n11NFNumero[0] )
            {
               AV12NFNumero = "";
               nV12NFNumero = false;
               nV12NFNumero = true;
            }
            else
            {
               AV12NFNumero = A11NFNumero;
               nV12NFNumero = false;
            }
            if ( OBITOSCONV2_n12NFValor[0] )
            {
               AV13NFValor = 0;
               nV13NFValor = false;
               nV13NFValor = true;
            }
            else
            {
               AV13NFValor = A12NFValor;
               nV13NFValor = false;
            }
            if ( OBITOSCONV2_n13Funeraria[0] )
            {
               AV14Funeraria = "";
               nV14Funeraria = false;
               nV14Funeraria = true;
            }
            else
            {
               AV14Funeraria = A13Funeraria;
               nV14Funeraria = false;
            }
            if ( OBITOSCONV2_n14Observacao[0] )
            {
               AV15Observacao = "";
               nV15Observacao = false;
               nV15Observacao = true;
            }
            else
            {
               AV15Observacao = A14Observacao;
               nV15Observacao = false;
            }
            if ( OBITOSCONV2_n15Parentesco[0] )
            {
               AV16Parentesco = "";
               nV16Parentesco = false;
               nV16Parentesco = true;
            }
            else
            {
               AV16Parentesco = A15Parentesco;
               nV16Parentesco = false;
            }
            if ( OBITOSCONV2_n16Cemiterio[0] )
            {
               AV17Cemiterio = 0;
               nV17Cemiterio = false;
               nV17Cemiterio = true;
            }
            else
            {
               AV17Cemiterio = A16Cemiterio;
               nV17Cemiterio = false;
            }
            if ( OBITOSCONV2_n17Jazigo[0] )
            {
               AV18Jazigo = 0;
               nV18Jazigo = false;
               nV18Jazigo = true;
            }
            else
            {
               AV18Jazigo = A17Jazigo;
               nV18Jazigo = false;
            }
            if ( OBITOSCONV2_n18Quadra[0] )
            {
               AV19Quadra = 0;
               nV19Quadra = false;
               nV19Quadra = true;
            }
            else
            {
               AV19Quadra = A18Quadra;
               nV19Quadra = false;
            }
            if ( OBITOSCONV2_n19Lote[0] )
            {
               AV20Lote = 0;
               nV20Lote = false;
               nV20Lote = true;
            }
            else
            {
               AV20Lote = A19Lote;
               nV20Lote = false;
            }
            if ( OBITOSCONV2_n20SeqDependente[0] )
            {
               AV21SeqDependente = 0;
               nV21SeqDependente = false;
               nV21SeqDependente = true;
            }
            else
            {
               AV21SeqDependente = A20SeqDependente;
               nV21SeqDependente = false;
            }
            if ( OBITOSCONV2_n21Capela[0] )
            {
               AV22Capela = 0;
               nV22Capela = false;
               nV22Capela = true;
            }
            else
            {
               AV22Capela = A21Capela;
               nV22Capela = false;
            }
            if ( OBITOSCONV2_n22EnderecoFalecido[0] )
            {
               AV23EnderecoFalecido = "";
               nV23EnderecoFalecido = false;
               nV23EnderecoFalecido = true;
            }
            else
            {
               AV23EnderecoFalecido = A22EnderecoFalecido;
               nV23EnderecoFalecido = false;
            }
            if ( OBITOSCONV2_n23horafalecimento[0] )
            {
               AV24horafalecimento = "";
               nV24horafalecimento = false;
               nV24horafalecimento = true;
            }
            else
            {
               AV24horafalecimento = A23horafalecimento;
               nV24horafalecimento = false;
            }
            if ( OBITOSCONV2_n24CidadeFalecimento[0] )
            {
               AV25CidadeFalecimento = 0;
               nV25CidadeFalecimento = false;
               nV25CidadeFalecimento = true;
            }
            else
            {
               AV25CidadeFalecimento = A24CidadeFalecimento;
               nV25CidadeFalecimento = false;
            }
            if ( OBITOSCONV2_n25LocalFalecimento[0] )
            {
               AV26LocalFalecimento = "";
               nV26LocalFalecimento = false;
               nV26LocalFalecimento = true;
            }
            else
            {
               AV26LocalFalecimento = A25LocalFalecimento;
               nV26LocalFalecimento = false;
            }
            if ( OBITOSCONV2_n26HoraSepultamento[0] )
            {
               AV27HoraSepultamento = "";
               nV27HoraSepultamento = false;
               nV27HoraSepultamento = true;
            }
            else
            {
               AV27HoraSepultamento = A26HoraSepultamento;
               nV27HoraSepultamento = false;
            }
            if ( OBITOSCONV2_n27DatasolicitacaoAux[0] )
            {
               AV28DatasolicitacaoAux = (DateTime)(DateTime.MinValue);
               nV28DatasolicitacaoAux = false;
               nV28DatasolicitacaoAux = true;
            }
            else
            {
               AV28DatasolicitacaoAux = A27DatasolicitacaoAux;
               nV28DatasolicitacaoAux = false;
            }
            if ( OBITOSCONV2_n28NomeContratanteAux[0] )
            {
               AV29NomeContratanteAux = "";
               nV29NomeContratanteAux = false;
               nV29NomeContratanteAux = true;
            }
            else
            {
               AV29NomeContratanteAux = A28NomeContratanteAux;
               nV29NomeContratanteAux = false;
            }
            if ( OBITOSCONV2_n29EndContratanteAux[0] )
            {
               AV30EndContratanteAux = "";
               nV30EndContratanteAux = false;
               nV30EndContratanteAux = true;
            }
            else
            {
               AV30EndContratanteAux = A29EndContratanteAux;
               nV30EndContratanteAux = false;
            }
            if ( OBITOSCONV2_n30CidadeContratanteAux[0] )
            {
               AV31CidadeContratanteAux = 0;
               nV31CidadeContratanteAux = false;
               nV31CidadeContratanteAux = true;
            }
            else
            {
               AV31CidadeContratanteAux = A30CidadeContratanteAux;
               nV31CidadeContratanteAux = false;
            }
            if ( OBITOSCONV2_n31RGContratanteAux[0] )
            {
               AV32RGContratanteAux = "";
               nV32RGContratanteAux = false;
               nV32RGContratanteAux = true;
            }
            else
            {
               AV32RGContratanteAux = A31RGContratanteAux;
               nV32RGContratanteAux = false;
            }
            if ( OBITOSCONV2_n32CPFContratanteAux[0] )
            {
               AV33CPFContratanteAux = "";
               nV33CPFContratanteAux = false;
               nV33CPFContratanteAux = true;
            }
            else
            {
               AV33CPFContratanteAux = A32CPFContratanteAux;
               nV33CPFContratanteAux = false;
            }
            if ( OBITOSCONV2_n33EstCivilContratanteAux[0] )
            {
               AV34EstCivilContratanteAux = 0;
               nV34EstCivilContratanteAux = false;
               nV34EstCivilContratanteAux = true;
            }
            else
            {
               AV34EstCivilContratanteAux = A33EstCivilContratanteAux;
               nV34EstCivilContratanteAux = false;
            }
            if ( OBITOSCONV2_n34DataInsert[0] )
            {
               AV35DataInsert = (DateTime)(DateTime.MinValue);
               nV35DataInsert = false;
               nV35DataInsert = true;
            }
            else
            {
               AV35DataInsert = A34DataInsert;
               nV35DataInsert = false;
            }
            if ( OBITOSCONV2_n35UsuInsert[0] )
            {
               AV36UsuInsert = 0;
               nV36UsuInsert = false;
               nV36UsuInsert = true;
            }
            else
            {
               AV36UsuInsert = A35UsuInsert;
               nV36UsuInsert = false;
            }
            if ( OBITOSCONV2_n36DataUpdate[0] )
            {
               AV37DataUpdate = (DateTime)(DateTime.MinValue);
               nV37DataUpdate = false;
               nV37DataUpdate = true;
            }
            else
            {
               AV37DataUpdate = A36DataUpdate;
               nV37DataUpdate = false;
            }
            if ( OBITOSCONV2_n37UsuUpdate[0] )
            {
               AV38UsuUpdate = 0;
               nV38UsuUpdate = false;
               nV38UsuUpdate = true;
            }
            else
            {
               AV38UsuUpdate = A37UsuUpdate;
               nV38UsuUpdate = false;
            }
            if ( OBITOSCONV2_n38NumControleAux[0] )
            {
               AV39NumControleAux = 0;
               nV39NumControleAux = false;
               nV39NumControleAux = true;
            }
            else
            {
               AV39NumControleAux = A38NumControleAux;
               nV39NumControleAux = false;
            }
            if ( OBITOSCONV2_n39ValorAux[0] )
            {
               AV40ValorAux = 0;
               nV40ValorAux = false;
               nV40ValorAux = true;
            }
            else
            {
               AV40ValorAux = A39ValorAux;
               nV40ValorAux = false;
            }
            if ( OBITOSCONV2_n40DataPagtoAux[0] )
            {
               AV41DataPagtoAux = (DateTime)(DateTime.MinValue);
               nV41DataPagtoAux = false;
               nV41DataPagtoAux = true;
            }
            else
            {
               AV41DataPagtoAux = A40DataPagtoAux;
               nV41DataPagtoAux = false;
            }
            if ( OBITOSCONV2_n41ObservacaoAux[0] )
            {
               AV42ObservacaoAux = "";
               nV42ObservacaoAux = false;
               nV42ObservacaoAux = true;
            }
            else
            {
               AV42ObservacaoAux = A41ObservacaoAux;
               nV42ObservacaoAux = false;
            }
            if ( OBITOSCONV2_n42EmCarencia[0] )
            {
               AV43EmCarencia = "";
               nV43EmCarencia = false;
               nV43EmCarencia = true;
            }
            else
            {
               AV43EmCarencia = A42EmCarencia;
               nV43EmCarencia = false;
            }
            if ( OBITOSCONV2_n43PercentualCobertura[0] )
            {
               AV44PercentualCobertura = 0;
               nV44PercentualCobertura = false;
               nV44PercentualCobertura = true;
            }
            else
            {
               AV44PercentualCobertura = A43PercentualCobertura;
               nV44PercentualCobertura = false;
            }
            if ( OBITOSCONV2_n44PacienteUnesp[0] )
            {
               AV45PacienteUnesp = "";
               nV45PacienteUnesp = false;
               nV45PacienteUnesp = true;
            }
            else
            {
               AV45PacienteUnesp = A44PacienteUnesp;
               nV45PacienteUnesp = false;
            }
            if ( OBITOSCONV2_n45RegistroUnesp[0] )
            {
               AV46RegistroUnesp = "";
               nV46RegistroUnesp = false;
               nV46RegistroUnesp = true;
            }
            else
            {
               AV46RegistroUnesp = A45RegistroUnesp;
               nV46RegistroUnesp = false;
            }
            if ( OBITOSCONV2_n46RelatoObito[0] )
            {
               AV47RelatoObito = "";
               nV47RelatoObito = false;
               nV47RelatoObito = true;
            }
            else
            {
               AV47RelatoObito = A46RelatoObito;
               nV47RelatoObito = false;
            }
            if ( OBITOSCONV2_n47ViciosHabituais[0] )
            {
               AV48ViciosHabituais = "";
               nV48ViciosHabituais = false;
               nV48ViciosHabituais = true;
            }
            else
            {
               AV48ViciosHabituais = A47ViciosHabituais;
               nV48ViciosHabituais = false;
            }
            if ( OBITOSCONV2_n48ViciosEspecificar[0] )
            {
               AV49ViciosEspecificar = "";
               nV49ViciosEspecificar = false;
               nV49ViciosEspecificar = true;
            }
            else
            {
               AV49ViciosEspecificar = A48ViciosEspecificar;
               nV49ViciosEspecificar = false;
            }
            if ( OBITOSCONV2_n49DoencasConhecidas[0] )
            {
               AV50DoencasConhecidas = "";
               nV50DoencasConhecidas = false;
               nV50DoencasConhecidas = true;
            }
            else
            {
               AV50DoencasConhecidas = A49DoencasConhecidas;
               nV50DoencasConhecidas = false;
            }
            if ( OBITOSCONV2_n50TaxaCapelaAux[0] )
            {
               AV51TaxaCapelaAux = 0;
               nV51TaxaCapelaAux = false;
               nV51TaxaCapelaAux = true;
            }
            else
            {
               AV51TaxaCapelaAux = A50TaxaCapelaAux;
               nV51TaxaCapelaAux = false;
            }
            if ( OBITOSCONV2_n51TaxaSepultamento[0] )
            {
               AV52TaxaSepultamento = 0;
               nV52TaxaSepultamento = false;
               nV52TaxaSepultamento = true;
            }
            else
            {
               AV52TaxaSepultamento = A51TaxaSepultamento;
               nV52TaxaSepultamento = false;
            }
            if ( OBITOSCONV2_n52Matricula[0] )
            {
               AV53Matricula = "";
               nV53Matricula = false;
               nV53Matricula = true;
            }
            else
            {
               AV53Matricula = A52Matricula;
               nV53Matricula = false;
            }
            if ( OBITOSCONV2_n53UsouCremacao[0] )
            {
               AV54UsouCremacao = "";
               nV54UsouCremacao = false;
               nV54UsouCremacao = true;
            }
            else
            {
               AV54UsouCremacao = A53UsouCremacao;
               nV54UsouCremacao = false;
            }
            if ( OBITOSCONV2_n54Seq[0] )
            {
               AV55Seq = 0;
               nV55Seq = false;
               nV55Seq = true;
            }
            else
            {
               AV55Seq = A54Seq;
               nV55Seq = false;
            }
            /* Using cursor OBITOSCONV3 */
            pr_default.execute(0, new Object[] {AV2Inscricao, AV3Nome, nV4Grupo, AV4Grupo, nV5Referencia, AV5Referencia, nV6Numero, AV6Numero, nV7Valor, AV7Valor, nV8Vencimento, AV8Vencimento, nV9Nascimento, AV9Nascimento, nV10Falecimento, AV10Falecimento, nV11NumeroObito, AV11NumeroObito, nV12NFNumero, AV12NFNumero, nV13NFValor, AV13NFValor, nV14Funeraria, AV14Funeraria, nV15Observacao, AV15Observacao, nV16Parentesco, AV16Parentesco, nV17Cemiterio, AV17Cemiterio, nV18Jazigo, AV18Jazigo, nV19Quadra, AV19Quadra, nV20Lote, AV20Lote, nV21SeqDependente, AV21SeqDependente, nV22Capela, AV22Capela, nV23EnderecoFalecido, AV23EnderecoFalecido, nV24horafalecimento, AV24horafalecimento, nV25CidadeFalecimento, AV25CidadeFalecimento, nV26LocalFalecimento, AV26LocalFalecimento, nV27HoraSepultamento, AV27HoraSepultamento, nV28DatasolicitacaoAux, AV28DatasolicitacaoAux, nV29NomeContratanteAux, AV29NomeContratanteAux, nV30EndContratanteAux, AV30EndContratanteAux, nV31CidadeContratanteAux, AV31CidadeContratanteAux, nV32RGContratanteAux, AV32RGContratanteAux, nV33CPFContratanteAux, AV33CPFContratanteAux, nV34EstCivilContratanteAux, AV34EstCivilContratanteAux, nV35DataInsert, AV35DataInsert, nV36UsuInsert, AV36UsuInsert, nV37DataUpdate, AV37DataUpdate, nV38UsuUpdate, AV38UsuUpdate, nV39NumControleAux, AV39NumControleAux, nV40ValorAux, AV40ValorAux, nV41DataPagtoAux, AV41DataPagtoAux, nV42ObservacaoAux, AV42ObservacaoAux, nV43EmCarencia, AV43EmCarencia, nV44PercentualCobertura, AV44PercentualCobertura, nV45PacienteUnesp, AV45PacienteUnesp, nV46RegistroUnesp, AV46RegistroUnesp, nV47RelatoObito, AV47RelatoObito, nV48ViciosHabituais, AV48ViciosHabituais, nV49ViciosEspecificar, AV49ViciosEspecificar, nV50DoencasConhecidas, AV50DoencasConhecidas, nV51TaxaCapelaAux, AV51TaxaCapelaAux, nV52TaxaSepultamento, AV52TaxaSepultamento, nV53Matricula, AV53Matricula, nV54UsouCremacao, AV54UsouCremacao, nV55Seq, AV55Seq});
            pr_default.close(0);
            pr_default.SmartCacheProvider.SetUpdated("GXA0001");
            if ( (pr_default.getStatus(0) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_datastore1.readNext(0);
         }
         pr_datastore1.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         OBITOSCONV2_A54Seq = new int[1] ;
         OBITOSCONV2_n54Seq = new bool[] {false} ;
         OBITOSCONV2_A53UsouCremacao = new string[] {""} ;
         OBITOSCONV2_n53UsouCremacao = new bool[] {false} ;
         OBITOSCONV2_A52Matricula = new string[] {""} ;
         OBITOSCONV2_n52Matricula = new bool[] {false} ;
         OBITOSCONV2_A51TaxaSepultamento = new decimal[1] ;
         OBITOSCONV2_n51TaxaSepultamento = new bool[] {false} ;
         OBITOSCONV2_A50TaxaCapelaAux = new decimal[1] ;
         OBITOSCONV2_n50TaxaCapelaAux = new bool[] {false} ;
         OBITOSCONV2_A49DoencasConhecidas = new string[] {""} ;
         OBITOSCONV2_n49DoencasConhecidas = new bool[] {false} ;
         OBITOSCONV2_A48ViciosEspecificar = new string[] {""} ;
         OBITOSCONV2_n48ViciosEspecificar = new bool[] {false} ;
         OBITOSCONV2_A47ViciosHabituais = new string[] {""} ;
         OBITOSCONV2_n47ViciosHabituais = new bool[] {false} ;
         OBITOSCONV2_A46RelatoObito = new string[] {""} ;
         OBITOSCONV2_n46RelatoObito = new bool[] {false} ;
         OBITOSCONV2_A45RegistroUnesp = new string[] {""} ;
         OBITOSCONV2_n45RegistroUnesp = new bool[] {false} ;
         OBITOSCONV2_A44PacienteUnesp = new string[] {""} ;
         OBITOSCONV2_n44PacienteUnesp = new bool[] {false} ;
         OBITOSCONV2_A43PercentualCobertura = new decimal[1] ;
         OBITOSCONV2_n43PercentualCobertura = new bool[] {false} ;
         OBITOSCONV2_A42EmCarencia = new string[] {""} ;
         OBITOSCONV2_n42EmCarencia = new bool[] {false} ;
         OBITOSCONV2_A41ObservacaoAux = new string[] {""} ;
         OBITOSCONV2_n41ObservacaoAux = new bool[] {false} ;
         OBITOSCONV2_A40DataPagtoAux = new DateTime[] {DateTime.MinValue} ;
         OBITOSCONV2_n40DataPagtoAux = new bool[] {false} ;
         OBITOSCONV2_A39ValorAux = new decimal[1] ;
         OBITOSCONV2_n39ValorAux = new bool[] {false} ;
         OBITOSCONV2_A38NumControleAux = new int[1] ;
         OBITOSCONV2_n38NumControleAux = new bool[] {false} ;
         OBITOSCONV2_A37UsuUpdate = new int[1] ;
         OBITOSCONV2_n37UsuUpdate = new bool[] {false} ;
         OBITOSCONV2_A36DataUpdate = new DateTime[] {DateTime.MinValue} ;
         OBITOSCONV2_n36DataUpdate = new bool[] {false} ;
         OBITOSCONV2_A35UsuInsert = new int[1] ;
         OBITOSCONV2_n35UsuInsert = new bool[] {false} ;
         OBITOSCONV2_A34DataInsert = new DateTime[] {DateTime.MinValue} ;
         OBITOSCONV2_n34DataInsert = new bool[] {false} ;
         OBITOSCONV2_A33EstCivilContratanteAux = new int[1] ;
         OBITOSCONV2_n33EstCivilContratanteAux = new bool[] {false} ;
         OBITOSCONV2_A32CPFContratanteAux = new string[] {""} ;
         OBITOSCONV2_n32CPFContratanteAux = new bool[] {false} ;
         OBITOSCONV2_A31RGContratanteAux = new string[] {""} ;
         OBITOSCONV2_n31RGContratanteAux = new bool[] {false} ;
         OBITOSCONV2_A30CidadeContratanteAux = new int[1] ;
         OBITOSCONV2_n30CidadeContratanteAux = new bool[] {false} ;
         OBITOSCONV2_A29EndContratanteAux = new string[] {""} ;
         OBITOSCONV2_n29EndContratanteAux = new bool[] {false} ;
         OBITOSCONV2_A28NomeContratanteAux = new string[] {""} ;
         OBITOSCONV2_n28NomeContratanteAux = new bool[] {false} ;
         OBITOSCONV2_A27DatasolicitacaoAux = new DateTime[] {DateTime.MinValue} ;
         OBITOSCONV2_n27DatasolicitacaoAux = new bool[] {false} ;
         OBITOSCONV2_A26HoraSepultamento = new string[] {""} ;
         OBITOSCONV2_n26HoraSepultamento = new bool[] {false} ;
         OBITOSCONV2_A25LocalFalecimento = new string[] {""} ;
         OBITOSCONV2_n25LocalFalecimento = new bool[] {false} ;
         OBITOSCONV2_A24CidadeFalecimento = new int[1] ;
         OBITOSCONV2_n24CidadeFalecimento = new bool[] {false} ;
         OBITOSCONV2_A23horafalecimento = new string[] {""} ;
         OBITOSCONV2_n23horafalecimento = new bool[] {false} ;
         OBITOSCONV2_A22EnderecoFalecido = new string[] {""} ;
         OBITOSCONV2_n22EnderecoFalecido = new bool[] {false} ;
         OBITOSCONV2_A21Capela = new int[1] ;
         OBITOSCONV2_n21Capela = new bool[] {false} ;
         OBITOSCONV2_A20SeqDependente = new int[1] ;
         OBITOSCONV2_n20SeqDependente = new bool[] {false} ;
         OBITOSCONV2_A19Lote = new int[1] ;
         OBITOSCONV2_n19Lote = new bool[] {false} ;
         OBITOSCONV2_A18Quadra = new int[1] ;
         OBITOSCONV2_n18Quadra = new bool[] {false} ;
         OBITOSCONV2_A17Jazigo = new int[1] ;
         OBITOSCONV2_n17Jazigo = new bool[] {false} ;
         OBITOSCONV2_A16Cemiterio = new int[1] ;
         OBITOSCONV2_n16Cemiterio = new bool[] {false} ;
         OBITOSCONV2_A15Parentesco = new string[] {""} ;
         OBITOSCONV2_n15Parentesco = new bool[] {false} ;
         OBITOSCONV2_A14Observacao = new string[] {""} ;
         OBITOSCONV2_n14Observacao = new bool[] {false} ;
         OBITOSCONV2_A13Funeraria = new string[] {""} ;
         OBITOSCONV2_n13Funeraria = new bool[] {false} ;
         OBITOSCONV2_A12NFValor = new decimal[1] ;
         OBITOSCONV2_n12NFValor = new bool[] {false} ;
         OBITOSCONV2_A11NFNumero = new string[] {""} ;
         OBITOSCONV2_n11NFNumero = new bool[] {false} ;
         OBITOSCONV2_A10NumeroObito = new string[] {""} ;
         OBITOSCONV2_n10NumeroObito = new bool[] {false} ;
         OBITOSCONV2_A7Vencimento = new DateTime[] {DateTime.MinValue} ;
         OBITOSCONV2_n7Vencimento = new bool[] {false} ;
         OBITOSCONV2_A6Valor = new decimal[1] ;
         OBITOSCONV2_n6Valor = new bool[] {false} ;
         OBITOSCONV2_A5Numero = new int[1] ;
         OBITOSCONV2_n5Numero = new bool[] {false} ;
         OBITOSCONV2_A4Referencia = new string[] {""} ;
         OBITOSCONV2_n4Referencia = new bool[] {false} ;
         OBITOSCONV2_A3Grupo = new string[] {""} ;
         OBITOSCONV2_n3Grupo = new bool[] {false} ;
         OBITOSCONV2_A2Nome = new string[] {""} ;
         OBITOSCONV2_A1Inscricao = new int[1] ;
         OBITOSCONV2_A8Nascimento = new DateTime[] {DateTime.MinValue} ;
         OBITOSCONV2_n8Nascimento = new bool[] {false} ;
         OBITOSCONV2_A9Falecimento = new DateTime[] {DateTime.MinValue} ;
         OBITOSCONV2_n9Falecimento = new bool[] {false} ;
         A53UsouCremacao = "";
         A52Matricula = "";
         A49DoencasConhecidas = "";
         A48ViciosEspecificar = "";
         A47ViciosHabituais = "";
         A46RelatoObito = "";
         A45RegistroUnesp = "";
         A44PacienteUnesp = "";
         A42EmCarencia = "";
         A41ObservacaoAux = "";
         A40DataPagtoAux = (DateTime)(DateTime.MinValue);
         A36DataUpdate = (DateTime)(DateTime.MinValue);
         A34DataInsert = (DateTime)(DateTime.MinValue);
         A32CPFContratanteAux = "";
         A31RGContratanteAux = "";
         A29EndContratanteAux = "";
         A28NomeContratanteAux = "";
         A27DatasolicitacaoAux = (DateTime)(DateTime.MinValue);
         A26HoraSepultamento = "";
         A25LocalFalecimento = "";
         A23horafalecimento = "";
         A22EnderecoFalecido = "";
         A15Parentesco = "";
         A14Observacao = "";
         A13Funeraria = "";
         A11NFNumero = "";
         A10NumeroObito = "";
         A7Vencimento = (DateTime)(DateTime.MinValue);
         A4Referencia = "";
         A3Grupo = "";
         A2Nome = "";
         A8Nascimento = (DateTime)(DateTime.MinValue);
         A9Falecimento = (DateTime)(DateTime.MinValue);
         A40001GXC2 = DateTime.MinValue;
         A40000GXC1 = DateTime.MinValue;
         AV3Nome = "";
         AV4Grupo = "";
         AV5Referencia = "";
         AV8Vencimento = (DateTime)(DateTime.MinValue);
         AV9Nascimento = DateTime.MinValue;
         AV10Falecimento = DateTime.MinValue;
         AV11NumeroObito = "";
         AV12NFNumero = "";
         AV14Funeraria = "";
         AV15Observacao = "";
         AV16Parentesco = "";
         AV23EnderecoFalecido = "";
         AV24horafalecimento = "";
         AV26LocalFalecimento = "";
         AV27HoraSepultamento = "";
         AV28DatasolicitacaoAux = (DateTime)(DateTime.MinValue);
         AV29NomeContratanteAux = "";
         AV30EndContratanteAux = "";
         AV32RGContratanteAux = "";
         AV33CPFContratanteAux = "";
         AV35DataInsert = (DateTime)(DateTime.MinValue);
         AV37DataUpdate = (DateTime)(DateTime.MinValue);
         AV41DataPagtoAux = (DateTime)(DateTime.MinValue);
         AV42ObservacaoAux = "";
         AV43EmCarencia = "";
         AV45PacienteUnesp = "";
         AV46RegistroUnesp = "";
         AV47RelatoObito = "";
         AV48ViciosHabituais = "";
         AV49ViciosEspecificar = "";
         AV50DoencasConhecidas = "";
         AV53Matricula = "";
         AV54UsouCremacao = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obitosconversion__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.obitosconversion__datastore1(),
            new Object[][] {
                new Object[] {
               OBITOSCONV2_A54Seq, OBITOSCONV2_n54Seq, OBITOSCONV2_A53UsouCremacao, OBITOSCONV2_n53UsouCremacao, OBITOSCONV2_A52Matricula, OBITOSCONV2_n52Matricula, OBITOSCONV2_A51TaxaSepultamento, OBITOSCONV2_n51TaxaSepultamento, OBITOSCONV2_A50TaxaCapelaAux, OBITOSCONV2_n50TaxaCapelaAux,
               OBITOSCONV2_A49DoencasConhecidas, OBITOSCONV2_n49DoencasConhecidas, OBITOSCONV2_A48ViciosEspecificar, OBITOSCONV2_n48ViciosEspecificar, OBITOSCONV2_A47ViciosHabituais, OBITOSCONV2_n47ViciosHabituais, OBITOSCONV2_A46RelatoObito, OBITOSCONV2_n46RelatoObito, OBITOSCONV2_A45RegistroUnesp, OBITOSCONV2_n45RegistroUnesp,
               OBITOSCONV2_A44PacienteUnesp, OBITOSCONV2_n44PacienteUnesp, OBITOSCONV2_A43PercentualCobertura, OBITOSCONV2_n43PercentualCobertura, OBITOSCONV2_A42EmCarencia, OBITOSCONV2_n42EmCarencia, OBITOSCONV2_A41ObservacaoAux, OBITOSCONV2_n41ObservacaoAux, OBITOSCONV2_A40DataPagtoAux, OBITOSCONV2_n40DataPagtoAux,
               OBITOSCONV2_A39ValorAux, OBITOSCONV2_n39ValorAux, OBITOSCONV2_A38NumControleAux, OBITOSCONV2_n38NumControleAux, OBITOSCONV2_A37UsuUpdate, OBITOSCONV2_n37UsuUpdate, OBITOSCONV2_A36DataUpdate, OBITOSCONV2_n36DataUpdate, OBITOSCONV2_A35UsuInsert, OBITOSCONV2_n35UsuInsert,
               OBITOSCONV2_A34DataInsert, OBITOSCONV2_n34DataInsert, OBITOSCONV2_A33EstCivilContratanteAux, OBITOSCONV2_n33EstCivilContratanteAux, OBITOSCONV2_A32CPFContratanteAux, OBITOSCONV2_n32CPFContratanteAux, OBITOSCONV2_A31RGContratanteAux, OBITOSCONV2_n31RGContratanteAux, OBITOSCONV2_A30CidadeContratanteAux, OBITOSCONV2_n30CidadeContratanteAux,
               OBITOSCONV2_A29EndContratanteAux, OBITOSCONV2_n29EndContratanteAux, OBITOSCONV2_A28NomeContratanteAux, OBITOSCONV2_n28NomeContratanteAux, OBITOSCONV2_A27DatasolicitacaoAux, OBITOSCONV2_n27DatasolicitacaoAux, OBITOSCONV2_A26HoraSepultamento, OBITOSCONV2_n26HoraSepultamento, OBITOSCONV2_A25LocalFalecimento, OBITOSCONV2_n25LocalFalecimento,
               OBITOSCONV2_A24CidadeFalecimento, OBITOSCONV2_n24CidadeFalecimento, OBITOSCONV2_A23horafalecimento, OBITOSCONV2_n23horafalecimento, OBITOSCONV2_A22EnderecoFalecido, OBITOSCONV2_n22EnderecoFalecido, OBITOSCONV2_A21Capela, OBITOSCONV2_n21Capela, OBITOSCONV2_A20SeqDependente, OBITOSCONV2_n20SeqDependente,
               OBITOSCONV2_A19Lote, OBITOSCONV2_n19Lote, OBITOSCONV2_A18Quadra, OBITOSCONV2_n18Quadra, OBITOSCONV2_A17Jazigo, OBITOSCONV2_n17Jazigo, OBITOSCONV2_A16Cemiterio, OBITOSCONV2_n16Cemiterio, OBITOSCONV2_A15Parentesco, OBITOSCONV2_n15Parentesco,
               OBITOSCONV2_A14Observacao, OBITOSCONV2_n14Observacao, OBITOSCONV2_A13Funeraria, OBITOSCONV2_n13Funeraria, OBITOSCONV2_A12NFValor, OBITOSCONV2_n12NFValor, OBITOSCONV2_A11NFNumero, OBITOSCONV2_n11NFNumero, OBITOSCONV2_A10NumeroObito, OBITOSCONV2_n10NumeroObito,
               OBITOSCONV2_A7Vencimento, OBITOSCONV2_n7Vencimento, OBITOSCONV2_A6Valor, OBITOSCONV2_n6Valor, OBITOSCONV2_A5Numero, OBITOSCONV2_n5Numero, OBITOSCONV2_A4Referencia, OBITOSCONV2_n4Referencia, OBITOSCONV2_A3Grupo, OBITOSCONV2_n3Grupo,
               OBITOSCONV2_A2Nome, OBITOSCONV2_A1Inscricao, OBITOSCONV2_A8Nascimento, OBITOSCONV2_n8Nascimento, OBITOSCONV2_A9Falecimento, OBITOSCONV2_n9Falecimento
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A54Seq ;
      private int A38NumControleAux ;
      private int A37UsuUpdate ;
      private int A35UsuInsert ;
      private int A33EstCivilContratanteAux ;
      private int A30CidadeContratanteAux ;
      private int A24CidadeFalecimento ;
      private int A21Capela ;
      private int A20SeqDependente ;
      private int A19Lote ;
      private int A18Quadra ;
      private int A17Jazigo ;
      private int A16Cemiterio ;
      private int A5Numero ;
      private int A1Inscricao ;
      private int GIGXA0001 ;
      private int AV2Inscricao ;
      private int AV6Numero ;
      private int AV17Cemiterio ;
      private int AV18Jazigo ;
      private int AV19Quadra ;
      private int AV20Lote ;
      private int AV21SeqDependente ;
      private int AV22Capela ;
      private int AV25CidadeFalecimento ;
      private int AV31CidadeContratanteAux ;
      private int AV34EstCivilContratanteAux ;
      private int AV36UsuInsert ;
      private int AV38UsuUpdate ;
      private int AV39NumControleAux ;
      private int AV55Seq ;
      private decimal A51TaxaSepultamento ;
      private decimal A50TaxaCapelaAux ;
      private decimal A43PercentualCobertura ;
      private decimal A39ValorAux ;
      private decimal A12NFValor ;
      private decimal A6Valor ;
      private decimal AV7Valor ;
      private decimal AV13NFValor ;
      private decimal AV40ValorAux ;
      private decimal AV44PercentualCobertura ;
      private decimal AV51TaxaCapelaAux ;
      private decimal AV52TaxaSepultamento ;
      private string A53UsouCremacao ;
      private string A47ViciosHabituais ;
      private string A44PacienteUnesp ;
      private string A42EmCarencia ;
      private string A15Parentesco ;
      private string A13Funeraria ;
      private string A4Referencia ;
      private string A3Grupo ;
      private string AV4Grupo ;
      private string AV5Referencia ;
      private string AV14Funeraria ;
      private string AV16Parentesco ;
      private string AV43EmCarencia ;
      private string AV45PacienteUnesp ;
      private string AV48ViciosHabituais ;
      private string AV54UsouCremacao ;
      private string Gx_emsg ;
      private DateTime A40DataPagtoAux ;
      private DateTime A36DataUpdate ;
      private DateTime A34DataInsert ;
      private DateTime A27DatasolicitacaoAux ;
      private DateTime A7Vencimento ;
      private DateTime A8Nascimento ;
      private DateTime A9Falecimento ;
      private DateTime AV8Vencimento ;
      private DateTime AV28DatasolicitacaoAux ;
      private DateTime AV35DataInsert ;
      private DateTime AV37DataUpdate ;
      private DateTime AV41DataPagtoAux ;
      private DateTime A40001GXC2 ;
      private DateTime A40000GXC1 ;
      private DateTime AV9Nascimento ;
      private DateTime AV10Falecimento ;
      private bool n54Seq ;
      private bool n53UsouCremacao ;
      private bool n52Matricula ;
      private bool n51TaxaSepultamento ;
      private bool n50TaxaCapelaAux ;
      private bool n49DoencasConhecidas ;
      private bool n48ViciosEspecificar ;
      private bool n47ViciosHabituais ;
      private bool n46RelatoObito ;
      private bool n45RegistroUnesp ;
      private bool n44PacienteUnesp ;
      private bool n43PercentualCobertura ;
      private bool n42EmCarencia ;
      private bool n41ObservacaoAux ;
      private bool n40DataPagtoAux ;
      private bool n39ValorAux ;
      private bool n38NumControleAux ;
      private bool n37UsuUpdate ;
      private bool n36DataUpdate ;
      private bool n35UsuInsert ;
      private bool n34DataInsert ;
      private bool n33EstCivilContratanteAux ;
      private bool n32CPFContratanteAux ;
      private bool n31RGContratanteAux ;
      private bool n30CidadeContratanteAux ;
      private bool n29EndContratanteAux ;
      private bool n28NomeContratanteAux ;
      private bool n27DatasolicitacaoAux ;
      private bool n26HoraSepultamento ;
      private bool n25LocalFalecimento ;
      private bool n24CidadeFalecimento ;
      private bool n23horafalecimento ;
      private bool n22EnderecoFalecido ;
      private bool n21Capela ;
      private bool n20SeqDependente ;
      private bool n19Lote ;
      private bool n18Quadra ;
      private bool n17Jazigo ;
      private bool n16Cemiterio ;
      private bool n15Parentesco ;
      private bool n14Observacao ;
      private bool n13Funeraria ;
      private bool n12NFValor ;
      private bool n11NFNumero ;
      private bool n10NumeroObito ;
      private bool n7Vencimento ;
      private bool n6Valor ;
      private bool n5Numero ;
      private bool n4Referencia ;
      private bool n3Grupo ;
      private bool n8Nascimento ;
      private bool n9Falecimento ;
      private bool nV4Grupo ;
      private bool nV5Referencia ;
      private bool nV6Numero ;
      private bool nV7Valor ;
      private bool nV8Vencimento ;
      private bool nV9Nascimento ;
      private bool nV10Falecimento ;
      private bool nV11NumeroObito ;
      private bool nV12NFNumero ;
      private bool nV13NFValor ;
      private bool nV14Funeraria ;
      private bool nV15Observacao ;
      private bool nV16Parentesco ;
      private bool nV17Cemiterio ;
      private bool nV18Jazigo ;
      private bool nV19Quadra ;
      private bool nV20Lote ;
      private bool nV21SeqDependente ;
      private bool nV22Capela ;
      private bool nV23EnderecoFalecido ;
      private bool nV24horafalecimento ;
      private bool nV25CidadeFalecimento ;
      private bool nV26LocalFalecimento ;
      private bool nV27HoraSepultamento ;
      private bool nV28DatasolicitacaoAux ;
      private bool nV29NomeContratanteAux ;
      private bool nV30EndContratanteAux ;
      private bool nV31CidadeContratanteAux ;
      private bool nV32RGContratanteAux ;
      private bool nV33CPFContratanteAux ;
      private bool nV34EstCivilContratanteAux ;
      private bool nV35DataInsert ;
      private bool nV36UsuInsert ;
      private bool nV37DataUpdate ;
      private bool nV38UsuUpdate ;
      private bool nV39NumControleAux ;
      private bool nV40ValorAux ;
      private bool nV41DataPagtoAux ;
      private bool nV42ObservacaoAux ;
      private bool nV43EmCarencia ;
      private bool nV44PercentualCobertura ;
      private bool nV45PacienteUnesp ;
      private bool nV46RegistroUnesp ;
      private bool nV47RelatoObito ;
      private bool nV48ViciosHabituais ;
      private bool nV49ViciosEspecificar ;
      private bool nV50DoencasConhecidas ;
      private bool nV51TaxaCapelaAux ;
      private bool nV52TaxaSepultamento ;
      private bool nV53Matricula ;
      private bool nV54UsouCremacao ;
      private bool nV55Seq ;
      private string A46RelatoObito ;
      private string AV47RelatoObito ;
      private string A52Matricula ;
      private string A49DoencasConhecidas ;
      private string A48ViciosEspecificar ;
      private string A45RegistroUnesp ;
      private string A41ObservacaoAux ;
      private string A32CPFContratanteAux ;
      private string A31RGContratanteAux ;
      private string A29EndContratanteAux ;
      private string A28NomeContratanteAux ;
      private string A26HoraSepultamento ;
      private string A25LocalFalecimento ;
      private string A23horafalecimento ;
      private string A22EnderecoFalecido ;
      private string A14Observacao ;
      private string A11NFNumero ;
      private string A10NumeroObito ;
      private string A2Nome ;
      private string AV3Nome ;
      private string AV11NumeroObito ;
      private string AV12NFNumero ;
      private string AV15Observacao ;
      private string AV23EnderecoFalecido ;
      private string AV24horafalecimento ;
      private string AV26LocalFalecimento ;
      private string AV27HoraSepultamento ;
      private string AV29NomeContratanteAux ;
      private string AV30EndContratanteAux ;
      private string AV32RGContratanteAux ;
      private string AV33CPFContratanteAux ;
      private string AV42ObservacaoAux ;
      private string AV46RegistroUnesp ;
      private string AV49ViciosEspecificar ;
      private string AV50DoencasConhecidas ;
      private string AV53Matricula ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] OBITOSCONV2_A54Seq ;
      private bool[] OBITOSCONV2_n54Seq ;
      private string[] OBITOSCONV2_A53UsouCremacao ;
      private bool[] OBITOSCONV2_n53UsouCremacao ;
      private string[] OBITOSCONV2_A52Matricula ;
      private bool[] OBITOSCONV2_n52Matricula ;
      private decimal[] OBITOSCONV2_A51TaxaSepultamento ;
      private bool[] OBITOSCONV2_n51TaxaSepultamento ;
      private decimal[] OBITOSCONV2_A50TaxaCapelaAux ;
      private bool[] OBITOSCONV2_n50TaxaCapelaAux ;
      private string[] OBITOSCONV2_A49DoencasConhecidas ;
      private bool[] OBITOSCONV2_n49DoencasConhecidas ;
      private string[] OBITOSCONV2_A48ViciosEspecificar ;
      private bool[] OBITOSCONV2_n48ViciosEspecificar ;
      private string[] OBITOSCONV2_A47ViciosHabituais ;
      private bool[] OBITOSCONV2_n47ViciosHabituais ;
      private string[] OBITOSCONV2_A46RelatoObito ;
      private bool[] OBITOSCONV2_n46RelatoObito ;
      private string[] OBITOSCONV2_A45RegistroUnesp ;
      private bool[] OBITOSCONV2_n45RegistroUnesp ;
      private string[] OBITOSCONV2_A44PacienteUnesp ;
      private bool[] OBITOSCONV2_n44PacienteUnesp ;
      private decimal[] OBITOSCONV2_A43PercentualCobertura ;
      private bool[] OBITOSCONV2_n43PercentualCobertura ;
      private string[] OBITOSCONV2_A42EmCarencia ;
      private bool[] OBITOSCONV2_n42EmCarencia ;
      private string[] OBITOSCONV2_A41ObservacaoAux ;
      private bool[] OBITOSCONV2_n41ObservacaoAux ;
      private DateTime[] OBITOSCONV2_A40DataPagtoAux ;
      private bool[] OBITOSCONV2_n40DataPagtoAux ;
      private decimal[] OBITOSCONV2_A39ValorAux ;
      private bool[] OBITOSCONV2_n39ValorAux ;
      private int[] OBITOSCONV2_A38NumControleAux ;
      private bool[] OBITOSCONV2_n38NumControleAux ;
      private int[] OBITOSCONV2_A37UsuUpdate ;
      private bool[] OBITOSCONV2_n37UsuUpdate ;
      private DateTime[] OBITOSCONV2_A36DataUpdate ;
      private bool[] OBITOSCONV2_n36DataUpdate ;
      private int[] OBITOSCONV2_A35UsuInsert ;
      private bool[] OBITOSCONV2_n35UsuInsert ;
      private DateTime[] OBITOSCONV2_A34DataInsert ;
      private bool[] OBITOSCONV2_n34DataInsert ;
      private int[] OBITOSCONV2_A33EstCivilContratanteAux ;
      private bool[] OBITOSCONV2_n33EstCivilContratanteAux ;
      private string[] OBITOSCONV2_A32CPFContratanteAux ;
      private bool[] OBITOSCONV2_n32CPFContratanteAux ;
      private string[] OBITOSCONV2_A31RGContratanteAux ;
      private bool[] OBITOSCONV2_n31RGContratanteAux ;
      private int[] OBITOSCONV2_A30CidadeContratanteAux ;
      private bool[] OBITOSCONV2_n30CidadeContratanteAux ;
      private string[] OBITOSCONV2_A29EndContratanteAux ;
      private bool[] OBITOSCONV2_n29EndContratanteAux ;
      private string[] OBITOSCONV2_A28NomeContratanteAux ;
      private bool[] OBITOSCONV2_n28NomeContratanteAux ;
      private DateTime[] OBITOSCONV2_A27DatasolicitacaoAux ;
      private bool[] OBITOSCONV2_n27DatasolicitacaoAux ;
      private string[] OBITOSCONV2_A26HoraSepultamento ;
      private bool[] OBITOSCONV2_n26HoraSepultamento ;
      private string[] OBITOSCONV2_A25LocalFalecimento ;
      private bool[] OBITOSCONV2_n25LocalFalecimento ;
      private int[] OBITOSCONV2_A24CidadeFalecimento ;
      private bool[] OBITOSCONV2_n24CidadeFalecimento ;
      private string[] OBITOSCONV2_A23horafalecimento ;
      private bool[] OBITOSCONV2_n23horafalecimento ;
      private string[] OBITOSCONV2_A22EnderecoFalecido ;
      private bool[] OBITOSCONV2_n22EnderecoFalecido ;
      private int[] OBITOSCONV2_A21Capela ;
      private bool[] OBITOSCONV2_n21Capela ;
      private int[] OBITOSCONV2_A20SeqDependente ;
      private bool[] OBITOSCONV2_n20SeqDependente ;
      private int[] OBITOSCONV2_A19Lote ;
      private bool[] OBITOSCONV2_n19Lote ;
      private int[] OBITOSCONV2_A18Quadra ;
      private bool[] OBITOSCONV2_n18Quadra ;
      private int[] OBITOSCONV2_A17Jazigo ;
      private bool[] OBITOSCONV2_n17Jazigo ;
      private int[] OBITOSCONV2_A16Cemiterio ;
      private bool[] OBITOSCONV2_n16Cemiterio ;
      private string[] OBITOSCONV2_A15Parentesco ;
      private bool[] OBITOSCONV2_n15Parentesco ;
      private string[] OBITOSCONV2_A14Observacao ;
      private bool[] OBITOSCONV2_n14Observacao ;
      private string[] OBITOSCONV2_A13Funeraria ;
      private bool[] OBITOSCONV2_n13Funeraria ;
      private decimal[] OBITOSCONV2_A12NFValor ;
      private bool[] OBITOSCONV2_n12NFValor ;
      private string[] OBITOSCONV2_A11NFNumero ;
      private bool[] OBITOSCONV2_n11NFNumero ;
      private string[] OBITOSCONV2_A10NumeroObito ;
      private bool[] OBITOSCONV2_n10NumeroObito ;
      private DateTime[] OBITOSCONV2_A7Vencimento ;
      private bool[] OBITOSCONV2_n7Vencimento ;
      private decimal[] OBITOSCONV2_A6Valor ;
      private bool[] OBITOSCONV2_n6Valor ;
      private int[] OBITOSCONV2_A5Numero ;
      private bool[] OBITOSCONV2_n5Numero ;
      private string[] OBITOSCONV2_A4Referencia ;
      private bool[] OBITOSCONV2_n4Referencia ;
      private string[] OBITOSCONV2_A3Grupo ;
      private bool[] OBITOSCONV2_n3Grupo ;
      private string[] OBITOSCONV2_A2Nome ;
      private int[] OBITOSCONV2_A1Inscricao ;
      private DateTime[] OBITOSCONV2_A8Nascimento ;
      private bool[] OBITOSCONV2_n8Nascimento ;
      private DateTime[] OBITOSCONV2_A9Falecimento ;
      private bool[] OBITOSCONV2_n9Falecimento ;
      private IDataStoreProvider pr_default ;
   }

   public class obitosconversion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmOBITOSCONV3;
          prmOBITOSCONV3 = new Object[] {
          new ParDef("@AV2Inscricao",GXType.Int32,9,0) ,
          new ParDef("@AV3Nome",GXType.VarChar,50,0) ,
          new ParDef("@AV4Grupo",GXType.Char,5,0){Nullable=true} ,
          new ParDef("@AV5Referencia",GXType.Char,7,0){Nullable=true} ,
          new ParDef("@AV6Numero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV7Valor",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@AV8Vencimento",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@AV9Nascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@AV10Falecimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@AV11NumeroObito",GXType.VarChar,15,0){Nullable=true} ,
          new ParDef("@AV12NFNumero",GXType.VarChar,9,0){Nullable=true} ,
          new ParDef("@AV13NFValor",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@AV14Funeraria",GXType.Char,5,0){Nullable=true} ,
          new ParDef("@AV15Observacao",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV16Parentesco",GXType.Char,5,0){Nullable=true} ,
          new ParDef("@AV17Cemiterio",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV18Jazigo",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV19Quadra",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV20Lote",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV21SeqDependente",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV22Capela",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV23EnderecoFalecido",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("@AV24horafalecimento",GXType.VarChar,5,0){Nullable=true} ,
          new ParDef("@AV25CidadeFalecimento",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV26LocalFalecimento",GXType.VarChar,45,0){Nullable=true} ,
          new ParDef("@AV27HoraSepultamento",GXType.VarChar,5,0){Nullable=true} ,
          new ParDef("@AV28DatasolicitacaoAux",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@AV29NomeContratanteAux",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("@AV30EndContratanteAux",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("@AV31CidadeContratanteAux",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV32RGContratanteAux",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("@AV33CPFContratanteAux",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("@AV34EstCivilContratanteAux",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV35DataInsert",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@AV36UsuInsert",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV37DataUpdate",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@AV38UsuUpdate",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV39NumControleAux",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("@AV40ValorAux",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@AV41DataPagtoAux",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("@AV42ObservacaoAux",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("@AV43EmCarencia",GXType.Char,1,0){Nullable=true} ,
          new ParDef("@AV44PercentualCobertura",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@AV45PacienteUnesp",GXType.Char,1,0){Nullable=true} ,
          new ParDef("@AV46RegistroUnesp",GXType.VarChar,15,0){Nullable=true} ,
          new ParDef("@AV47RelatoObito",GXType.VarChar,16,0){Nullable=true} ,
          new ParDef("@AV48ViciosHabituais",GXType.Char,1,0){Nullable=true} ,
          new ParDef("@AV49ViciosEspecificar",GXType.VarChar,30,0){Nullable=true} ,
          new ParDef("@AV50DoencasConhecidas",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("@AV51TaxaCapelaAux",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@AV52TaxaSepultamento",GXType.Decimal,18,4){Nullable=true} ,
          new ParDef("@AV53Matricula",GXType.VarChar,38,0){Nullable=true} ,
          new ParDef("@AV54UsouCremacao",GXType.Char,1,0){Nullable=true} ,
          new ParDef("@AV55Seq",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferOBITOSCONV3;
          cmdBufferOBITOSCONV3=" INSERT INTO [GXA0001]([Inscricao], [Nome], [Grupo], [Referencia], [Numero], [Valor], [Vencimento], [Nascimento], [Falecimento], [NumeroObito], [NFNumero], [NFValor], [Funeraria], [Observacao], [Parentesco], [Cemiterio], [Jazigo], [Quadra], [Lote], [SeqDependente], [Capela], [EnderecoFalecido], [horafalecimento], [CidadeFalecimento], [LocalFalecimento], [HoraSepultamento], [DatasolicitacaoAux], [NomeContratanteAux], [EndContratanteAux], [CidadeContratanteAux], [RGContratanteAux], [CPFContratanteAux], [EstCivilContratanteAux], [DataInsert], [UsuInsert], [DataUpdate], [UsuUpdate], [NumControleAux], [ValorAux], [DataPagtoAux], [ObservacaoAux], [EmCarencia], [PercentualCobertura], [PacienteUnesp], [RegistroUnesp], [RelatoObito], [ViciosHabituais], [ViciosEspecificar], [DoencasConhecidas], [TaxaCapelaAux], [TaxaSepultamento], [Matricula], [UsouCremacao], [Seq]) VALUES(@AV2Inscricao, @AV3Nome, @AV4Grupo, @AV5Referencia, @AV6Numero, @AV7Valor, @AV8Vencimento, @AV9Nascimento, @AV10Falecimento, @AV11NumeroObito, @AV12NFNumero, @AV13NFValor, @AV14Funeraria, @AV15Observacao, @AV16Parentesco, @AV17Cemiterio, @AV18Jazigo, @AV19Quadra, @AV20Lote, @AV21SeqDependente, @AV22Capela, @AV23EnderecoFalecido, @AV24horafalecimento, @AV25CidadeFalecimento, @AV26LocalFalecimento, @AV27HoraSepultamento, @AV28DatasolicitacaoAux, @AV29NomeContratanteAux, @AV30EndContratanteAux, @AV31CidadeContratanteAux, @AV32RGContratanteAux, @AV33CPFContratanteAux, @AV34EstCivilContratanteAux, @AV35DataInsert, @AV36UsuInsert, @AV37DataUpdate, @AV38UsuUpdate, @AV39NumControleAux, @AV40ValorAux, @AV41DataPagtoAux, @AV42ObservacaoAux, @AV43EmCarencia, @AV44PercentualCobertura, @AV45PacienteUnesp, @AV46RegistroUnesp, @AV47RelatoObito, @AV48ViciosHabituais, @AV49ViciosEspecificar, @AV50DoencasConhecidas, @AV51TaxaCapelaAux, "
          + " @AV52TaxaSepultamento, @AV53Matricula, @AV54UsouCremacao, @AV55Seq)" ;
          def= new CursorDef[] {
              new CursorDef("OBITOSCONV3", cmdBufferOBITOSCONV3, GxErrorMask.GX_NOMASK,prmOBITOSCONV3)
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

 public class obitosconversion__datastore1 : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmOBITOSCONV2;
        prmOBITOSCONV2 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("OBITOSCONV2", "SELECT [Seq], [UsouCremacao], [Matricula], [TaxaSepultamento], [TaxaCapelaAux], [DoencasConhecidas], [ViciosEspecificar], [ViciosHabituais], [RelatoObito], [RegistroUnesp], [PacienteUnesp], [PercentualCobertura], [EmCarencia], [ObservacaoAux], [DataPagtoAux], [ValorAux], [NumControleAux], [UsuUpdate], [DataUpdate], [UsuInsert], [DataInsert], [EstCivilContratanteAux], [CPFContratanteAux], [RGContratanteAux], [CidadeContratanteAux], [EndContratanteAux], [NomeContratanteAux], [DatasolicitacaoAux], [HoraSepultamento], [LocalFalecimento], [CidadeFalecimento], [horafalecimento], [EnderecoFalecido], [Capela], [SeqDependente], [Lote], [Quadra], [Jazigo], [Cemiterio], [Parentesco], [Observacao], [Funeraria], [NFValor], [NFNumero], [NumeroObito], [Vencimento], [Valor], [Numero], [Referencia], [Grupo], [Nome], [Inscricao], [Nascimento], [Falecimento] FROM dbo.[Obitos] ORDER BY [Inscricao], [Nome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmOBITOSCONV2,100, GxCacheFrequency.OFF ,true,false )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 0 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 1);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getVarchar(3);
              ((bool[]) buf[5])[0] = rslt.wasNull(3);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
              ((bool[]) buf[7])[0] = rslt.wasNull(4);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
              ((bool[]) buf[9])[0] = rslt.wasNull(5);
              ((string[]) buf[10])[0] = rslt.getVarchar(6);
              ((bool[]) buf[11])[0] = rslt.wasNull(6);
              ((string[]) buf[12])[0] = rslt.getVarchar(7);
              ((bool[]) buf[13])[0] = rslt.wasNull(7);
              ((string[]) buf[14])[0] = rslt.getString(8, 1);
              ((bool[]) buf[15])[0] = rslt.wasNull(8);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[17])[0] = rslt.wasNull(9);
              ((string[]) buf[18])[0] = rslt.getVarchar(10);
              ((bool[]) buf[19])[0] = rslt.wasNull(10);
              ((string[]) buf[20])[0] = rslt.getString(11, 1);
              ((bool[]) buf[21])[0] = rslt.wasNull(11);
              ((decimal[]) buf[22])[0] = rslt.getDecimal(12);
              ((bool[]) buf[23])[0] = rslt.wasNull(12);
              ((string[]) buf[24])[0] = rslt.getString(13, 1);
              ((bool[]) buf[25])[0] = rslt.wasNull(13);
              ((string[]) buf[26])[0] = rslt.getVarchar(14);
              ((bool[]) buf[27])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[29])[0] = rslt.wasNull(15);
              ((decimal[]) buf[30])[0] = rslt.getDecimal(16);
              ((bool[]) buf[31])[0] = rslt.wasNull(16);
              ((int[]) buf[32])[0] = rslt.getInt(17);
              ((bool[]) buf[33])[0] = rslt.wasNull(17);
              ((int[]) buf[34])[0] = rslt.getInt(18);
              ((bool[]) buf[35])[0] = rslt.wasNull(18);
              ((DateTime[]) buf[36])[0] = rslt.getGXDateTime(19);
              ((bool[]) buf[37])[0] = rslt.wasNull(19);
              ((int[]) buf[38])[0] = rslt.getInt(20);
              ((bool[]) buf[39])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(21);
              ((bool[]) buf[41])[0] = rslt.wasNull(21);
              ((int[]) buf[42])[0] = rslt.getInt(22);
              ((bool[]) buf[43])[0] = rslt.wasNull(22);
              ((string[]) buf[44])[0] = rslt.getVarchar(23);
              ((bool[]) buf[45])[0] = rslt.wasNull(23);
              ((string[]) buf[46])[0] = rslt.getVarchar(24);
              ((bool[]) buf[47])[0] = rslt.wasNull(24);
              ((int[]) buf[48])[0] = rslt.getInt(25);
              ((bool[]) buf[49])[0] = rslt.wasNull(25);
              ((string[]) buf[50])[0] = rslt.getVarchar(26);
              ((bool[]) buf[51])[0] = rslt.wasNull(26);
              ((string[]) buf[52])[0] = rslt.getVarchar(27);
              ((bool[]) buf[53])[0] = rslt.wasNull(27);
              ((DateTime[]) buf[54])[0] = rslt.getGXDateTime(28);
              ((bool[]) buf[55])[0] = rslt.wasNull(28);
              ((string[]) buf[56])[0] = rslt.getVarchar(29);
              ((bool[]) buf[57])[0] = rslt.wasNull(29);
              ((string[]) buf[58])[0] = rslt.getVarchar(30);
              ((bool[]) buf[59])[0] = rslt.wasNull(30);
              ((int[]) buf[60])[0] = rslt.getInt(31);
              ((bool[]) buf[61])[0] = rslt.wasNull(31);
              ((string[]) buf[62])[0] = rslt.getVarchar(32);
              ((bool[]) buf[63])[0] = rslt.wasNull(32);
              ((string[]) buf[64])[0] = rslt.getVarchar(33);
              ((bool[]) buf[65])[0] = rslt.wasNull(33);
              ((int[]) buf[66])[0] = rslt.getInt(34);
              ((bool[]) buf[67])[0] = rslt.wasNull(34);
              ((int[]) buf[68])[0] = rslt.getInt(35);
              ((bool[]) buf[69])[0] = rslt.wasNull(35);
              ((int[]) buf[70])[0] = rslt.getInt(36);
              ((bool[]) buf[71])[0] = rslt.wasNull(36);
              ((int[]) buf[72])[0] = rslt.getInt(37);
              ((bool[]) buf[73])[0] = rslt.wasNull(37);
              ((int[]) buf[74])[0] = rslt.getInt(38);
              ((bool[]) buf[75])[0] = rslt.wasNull(38);
              ((int[]) buf[76])[0] = rslt.getInt(39);
              ((bool[]) buf[77])[0] = rslt.wasNull(39);
              ((string[]) buf[78])[0] = rslt.getString(40, 5);
              ((bool[]) buf[79])[0] = rslt.wasNull(40);
              ((string[]) buf[80])[0] = rslt.getVarchar(41);
              ((bool[]) buf[81])[0] = rslt.wasNull(41);
              ((string[]) buf[82])[0] = rslt.getString(42, 5);
              ((bool[]) buf[83])[0] = rslt.wasNull(42);
              ((decimal[]) buf[84])[0] = rslt.getDecimal(43);
              ((bool[]) buf[85])[0] = rslt.wasNull(43);
              ((string[]) buf[86])[0] = rslt.getVarchar(44);
              ((bool[]) buf[87])[0] = rslt.wasNull(44);
              ((string[]) buf[88])[0] = rslt.getVarchar(45);
              ((bool[]) buf[89])[0] = rslt.wasNull(45);
              ((DateTime[]) buf[90])[0] = rslt.getGXDateTime(46);
              ((bool[]) buf[91])[0] = rslt.wasNull(46);
              ((decimal[]) buf[92])[0] = rslt.getDecimal(47);
              ((bool[]) buf[93])[0] = rslt.wasNull(47);
              ((int[]) buf[94])[0] = rslt.getInt(48);
              ((bool[]) buf[95])[0] = rslt.wasNull(48);
              ((string[]) buf[96])[0] = rslt.getString(49, 7);
              ((bool[]) buf[97])[0] = rslt.wasNull(49);
              ((string[]) buf[98])[0] = rslt.getString(50, 5);
              ((bool[]) buf[99])[0] = rslt.wasNull(50);
              ((string[]) buf[100])[0] = rslt.getVarchar(51);
              ((int[]) buf[101])[0] = rslt.getInt(52);
              ((DateTime[]) buf[102])[0] = rslt.getGXDateTime(53);
              ((bool[]) buf[103])[0] = rslt.wasNull(53);
              ((DateTime[]) buf[104])[0] = rslt.getGXDateTime(54);
              ((bool[]) buf[105])[0] = rslt.wasNull(54);
              return;
     }
  }

  public override string getDataStoreName( )
  {
     return "DATASTORE1";
  }

}

}
