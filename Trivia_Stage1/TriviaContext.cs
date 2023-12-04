using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Stage1.Models;

    public partial class TriviaContext
    {
    public Q GetQ(int i)
    {
        return this.Qs.Where(x => x.Qid == i).FirstOrDefault();
    }

    public string GetAnsCorrect(int i)
    {
        return this.Qs.Where(x => x.Qid == i).FirstOrDefault().AnsCorrect;
    }
    public string GetAns1(int i)
    {
        return this.Qs.Where(x => x.Qid == i).FirstOrDefault().A1;
    }
    public string GetAns2(int i)
    {
        return this.Qs.Where(x => x.Qid == i).FirstOrDefault().A2;
    }
    public string GetAns3(int i)
    {
        return this.Qs.Where(x => x.Qid == i).FirstOrDefault().A3;
    }

}

