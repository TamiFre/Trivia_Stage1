using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
    public List<Q> GetPendingQs()
    {
        return this.Qs.Where(x => x.StatusId == 3).Include(q => q.Subject).Include(question => question.Player).ToList();
    }

    public List<Q> GetAddedQs(int i)
    {
        return this.Qs.Where(x=> x.PlayerId == i).ToList();
    }
    public string GetPlayerName(int i)
    {
        return this.Players.Where(x => x.PlayerId == i).FirstOrDefault().PlayerName;
    }
    public string GetPass(int i)
    {
        return this.Players.Where(x => x.PlayerId == i).FirstOrDefault().Pass;
    }
    public Player Login(string name, string pass)
    {
        return this.Players.Where(x => x.PlayerName == name).Include(x => x.Pass == pass).FirstOrDefault();
    }
}

