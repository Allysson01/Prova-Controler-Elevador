using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace ControleAcessoElevador
{
    public class LandingPageMessage : Message
    {
        private readonly MessageHeaders _headers;
        private readonly MessageProperties _properties;

        public LandingPageMessage()
        {
            this._headers = new MessageHeaders(MessageVersion.None);
            this._properties = new MessageProperties();
        }

        public override MessageHeaders Headers
        {
            get { return this._headers; }
        }

        public override MessageProperties Properties
        {
            get { return this._properties; }
        }

        public override MessageVersion Version
        {
            get { return this._headers.MessageVersion; }
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("HTML");
            writer.WriteStartElement("HEAD");
            writer.WriteStartElement("BODY");
            writer.WriteStartElement("SPAN");
            writer.WriteString("");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
