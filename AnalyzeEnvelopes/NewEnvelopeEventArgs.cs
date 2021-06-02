using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisOfEnvelopes
{
    public class NewEnvelopeEventArgs: EventArgs
    {
        private readonly String m_from, m_to, m_subject;
        public NewEnvelopeEventArgs(String from, String to, String subject)
        {
            m_from = from; m_to = to; m_subject = subject;
        }
        public String From { get { return m_from; } }
        public String To { get { return m_to; } }
        public String Subject { get { return m_subject; } }
    }
}
