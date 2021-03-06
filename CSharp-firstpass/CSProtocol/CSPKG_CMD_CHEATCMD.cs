﻿namespace CSProtocol
{
    using Assets.Scripts.Common;
    using System;
    using tsf4g_tdr_csharp;

    public class CSPKG_CMD_CHEATCMD : ProtocolObject
    {
        public static readonly uint BASEVERSION = 1;
        public static readonly int CLASS_ID = 0x2b8;
        public static readonly uint CURRVERSION = 0x87;
        public int iCheatCmd;
        public CSDT_CHEATCMD_DETAIL stCheatCmdDetail = ((CSDT_CHEATCMD_DETAIL) ProtocolObjectPool.Get(CSDT_CHEATCMD_DETAIL.CLASS_ID));

        public override TdrError.ErrorType construct()
        {
            TdrError.ErrorType type = TdrError.ErrorType.TDR_NO_ERROR;
            this.iCheatCmd = 0;
            long iCheatCmd = this.iCheatCmd;
            type = this.stCheatCmdDetail.construct(iCheatCmd);
            if (type != TdrError.ErrorType.TDR_NO_ERROR)
            {
                return type;
            }
            return type;
        }

        public override int GetClassID()
        {
            return CLASS_ID;
        }

        public override void OnRelease()
        {
            this.iCheatCmd = 0;
            if (this.stCheatCmdDetail != null)
            {
                this.stCheatCmdDetail.Release();
                this.stCheatCmdDetail = null;
            }
        }

        public override void OnUse()
        {
            this.stCheatCmdDetail = (CSDT_CHEATCMD_DETAIL) ProtocolObjectPool.Get(CSDT_CHEATCMD_DETAIL.CLASS_ID);
        }

        public override TdrError.ErrorType pack(ref TdrWriteBuf destBuf, uint cutVer)
        {
            TdrError.ErrorType type = TdrError.ErrorType.TDR_NO_ERROR;
            if ((cutVer == 0) || (CURRVERSION < cutVer))
            {
                cutVer = CURRVERSION;
            }
            if (BASEVERSION > cutVer)
            {
                return TdrError.ErrorType.TDR_ERR_CUTVER_TOO_SMALL;
            }
            type = destBuf.writeInt32(this.iCheatCmd);
            if (type == TdrError.ErrorType.TDR_NO_ERROR)
            {
                long iCheatCmd = this.iCheatCmd;
                type = this.stCheatCmdDetail.pack(iCheatCmd, ref destBuf, cutVer);
                if (type != TdrError.ErrorType.TDR_NO_ERROR)
                {
                    return type;
                }
            }
            return type;
        }

        public TdrError.ErrorType pack(ref byte[] buffer, int size, ref int usedSize, uint cutVer)
        {
            if (((buffer == null) || (buffer.GetLength(0) == 0)) || (size > buffer.GetLength(0)))
            {
                return TdrError.ErrorType.TDR_ERR_INVALID_BUFFER_PARAMETER;
            }
            TdrWriteBuf destBuf = ClassObjPool<TdrWriteBuf>.Get();
            destBuf.set(ref buffer, size);
            TdrError.ErrorType type = this.pack(ref destBuf, cutVer);
            if (type == TdrError.ErrorType.TDR_NO_ERROR)
            {
                buffer = destBuf.getBeginPtr();
                usedSize = destBuf.getUsedSize();
            }
            destBuf.Release();
            return type;
        }

        public override TdrError.ErrorType unpack(ref TdrReadBuf srcBuf, uint cutVer)
        {
            TdrError.ErrorType type = TdrError.ErrorType.TDR_NO_ERROR;
            if ((cutVer == 0) || (CURRVERSION < cutVer))
            {
                cutVer = CURRVERSION;
            }
            if (BASEVERSION > cutVer)
            {
                return TdrError.ErrorType.TDR_ERR_CUTVER_TOO_SMALL;
            }
            type = srcBuf.readInt32(ref this.iCheatCmd);
            if (type == TdrError.ErrorType.TDR_NO_ERROR)
            {
                long iCheatCmd = this.iCheatCmd;
                type = this.stCheatCmdDetail.unpack(iCheatCmd, ref srcBuf, cutVer);
                if (type != TdrError.ErrorType.TDR_NO_ERROR)
                {
                    return type;
                }
            }
            return type;
        }

        public TdrError.ErrorType unpack(ref byte[] buffer, int size, ref int usedSize, uint cutVer)
        {
            if (((buffer == null) || (buffer.GetLength(0) == 0)) || (size > buffer.GetLength(0)))
            {
                return TdrError.ErrorType.TDR_ERR_INVALID_BUFFER_PARAMETER;
            }
            TdrReadBuf srcBuf = ClassObjPool<TdrReadBuf>.Get();
            srcBuf.set(ref buffer, size);
            TdrError.ErrorType type = this.unpack(ref srcBuf, cutVer);
            usedSize = srcBuf.getUsedSize();
            srcBuf.Release();
            return type;
        }
    }
}

