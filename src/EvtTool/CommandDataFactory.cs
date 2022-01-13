namespace EvtTool
{
    public static class CommandDataFactory
    {
        public static CommandData Create( string type )
        {
            switch ( type )
            {
                case "AlEf":
                    return new AlEfCommandData();
                case "CAA_":
                    return new CaaCommandData();
                case "CAR_":
                    return new CarCommandData();
                case "CClp":
                    return new CClpCommandData();
                case "Chap":
                    return new ChapCommandData();
                case "Cht_":
                    return new ChtCommandData();
                case "CMCn":
                    return new CmCnCommandData();
                case "CMD_":
                    return new CmdCommandData();
                case "CQuk":
                    return new CQukCommandData();
                case "CSA_":
                    return new CsaCommandData();
                case "CSD_":
                    return new CsdCommandData();
                case "CSEc":
                    return new CsEcCommandData();
                case "CShk":
                    return new CShkCommandData();
                case "CwCl":
                    return new CwClCommandData();
                case "CwHt":
                    return new CwHtCommandData();
                case "CwP_":
                    return new CwPCommandData();
                case "Date":
                    return new DateCommandData();
                case "EAlp":
                    return new EAlpCommandData();
                case "ELd_":
                    return new ELdCommandData();
                case "EMD_":
                    return new EmdCommandData();
                case "EnBc":
                    return new EnBcCommandData();
                case "EnCc":
                    return new EnCcCommandData();
                case "EnDf":
                    return new EnDfCommandData();
                case "EnFD":
                    return new EnFdCommandData();
                case "EnFH":
                    return new EnFhCommandData();
                case "EnHd":
                    return new EnHdCommandData();
                case "EnL0":
                    return new EnL0CommandData();
                case "EnLI":
                    return new EnLiCommandData();
                case "EnOl":
                    return new EnOlCommandData();
                case "EnPh":
                    return new EnPhCommandData();
                case "EnSh":
                    return new EnShCommandData();
                case "Env_":
                    return new EnvCommandData();
                case "ERgs":
                    return new ERgsCommandData();
                case "EScl":
                    return new ESclCommandData();
                case "ESD_":
                    return new EsdCommandData();
                case "ESH_":
                    return new EshCommandData();
                case "FAA_":
                    return new FaaCommandData();
                case "FAB_":
                    return new FabCommandData();
                case "FbEn":
                    return new FbEnCommandData();
                case "Fd__":
                    return new FdCommandData();
                case "FDFl":
                    return new FdFlCommandData();
                case "FdS_":
                    return new FdSCommandData();
                case "FGFl":
                    return new FgFlCommandData();
                case "Flbk":
                    return new FlbkCommandData();
                case "FOD_":
                    return new FodCommandData();
                case "FrJ_":
                    return new FrJCommandData();
                case "FS__":
                    return new FsCommandData();
                case "GCAP":
                    return new GcapCommandData();
                case "GGGg":
                    return new GgGgCommandData();
                case "GPoe":
                    return new GPoeCommandData();
                case "ImDp":
                    return new ImDpCommandData();
                case "LBX_":
                    return new LbxCommandData();
                case "MAA_":
                    return new MaaCommandData();
                case "MAAB":
                    return new MaabCommandData();
                case "MAB_":
                    return new MabCommandData();
                case "MAI_":
                    return new MaiCommandData();
                case "MAlp":
                    return new MAlpCommandData();
                case "MAt_":
                    return new MAtCommandData();
                case "MAtO":
                    return new MatOCommandData();
                case "MCSd":
                    return new McSdCommandData();
                case "MDt_":
                    return new MDtCommandData();
                case "MFts":
                    return new MFtsCommandData();
                case "MIc_":
                    return new MIcCommandData();
                case "ML__":
                    return new MlCommandData();
                case "MLa_":
                    return new MLaCommandData();
                case "MLd_":
                    return new MLdCommandData();
                case "MLw_":
                    return new MLwCommandData();
                case "MMD_":
                    return new MmdCommandData();
                case "MRgs":
                    return new MRgsCommandData();
                case "MRot":
                    return new MRotCommandData();
                case "MScl":
                    return new MSclCommandData();
                case "MSD_":
                    return new MsdCommandData();
                case "Msg_":
                    return new MsgCommandData();
                case "MsgR":
                    return new MsgRCommandData();
                case "MSSs":
                    return new MsSsCommandData();
                case "MvCt":
                    return new MvCtCommandData();
                case "MvPl":
                    return new MvPlCommandData();
                case "PBDs":
                    return new PbDsCommandData();
                case "PBNs":
                    return new PbNsCommandData();
                case "PBRd":
                    return new PbRdCommandData();
                case "PBSt":
                    return new PbStCommandData();
                case "PCc_":
                    return new PCcCommandData();
                case "PLf_":
                    return new PLfCommandData();
                case "PRum":
                    return new PRumCommandData();
                case "Scr_":
                    return new ScrCommandData();
                case "SFlt":
                    return new SFltCommandData();
                case "SsCp":
                    return new SsCpCommandData();
                case "TCol":
                    return new ColCommandData();
                case "TRgs":
                    return new RgsCommandData();
                case "TrMt":
                    return new TrMtCommandData();
                case "TScl":
                    return new SclCommandData();

                // ECS commands
                case "SBE_":
                    return new SBECommandData();
                case "SBEA":
                    return new SBEACommandData();
                case "SFts":
                    return new SFtsCommandData();
                case "Snd_":
                    return new SndCommandData();

                default:
                    return new UnknownCommandData();
            }
        }
    }
}