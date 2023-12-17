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
    public Player Login(string name, string pass, string mail)
    {
        foreach (Player p in Players)
        {
            if (p.Pass == pass && p.PlayerName == name && p.Mail == mail)
                return p;
        }
        return null;
    }
    //public bool Login(string name, string pass, string mail)
    //{
    //    return this.Players.Where(x => x.PlayerName == name && x.Pass == pass && x.Mail == mail) != null;
    //}
    public void SetTitle(string? title,int i)
    {
        this.Qs.Where(x=>x.Qid ==i).FirstOrDefault().Title = title;
    }

    public int? GetSubjectId(int i)
    {
        return this.Qs.Where(x => x.Qid == i).FirstOrDefault().SubjectId;
    }

    public void SetSubject(string? subject, int i)
    {
        this.Subjects.Where(x => x.SubjectId ==GetSubjectId( i)).FirstOrDefault().SubjectName = subject;
    }
    public void SetCorrectAns(string? correctAns, int i)
    {
        this.Qs.Where(x => x.Qid == i).FirstOrDefault().AnsCorrect = correctAns;
    }

    public void SetA1(string? A1, int i)
    {
        this.Qs.Where(x => x.Qid == i).FirstOrDefault().A1 = A1;
    }
    public void SetA2(string? A2, int i)
    {
        this.Qs.Where(x => x.Qid == i).FirstOrDefault().A2 = A2;
    }

    public void SetA3(string? A3, int i)
    {
        this.Qs.Where(x => x.Qid == i).FirstOrDefault().A3 = A3;
    }

    public int? GetPoints(int i)
    {
        return this.Players.Where(x => x.PlayerId == i).FirstOrDefault().Points;
    }

    public void SetPoints(int i, int? points)
    {
        this.Players.Where(x => x.PlayerId == i).FirstOrDefault().Points = points;
    }

    public void SetQStatusToApprove(int i)
    {
        this.Qs.Where(x => x.Qid == i).FirstOrDefault().StatusId = 1;
    }
    public void SetQStatusToDeclined(int i)
    {
        this.Qs.Where(x => x.Qid == i).FirstOrDefault().StatusId = 2;
    }
    public string GetPlayerMail(int i)
    {
        return this.Players.Where(x => x.PlayerId == i).FirstOrDefault().Mail;
    }
    public int? GetDargaId(int i)
    {
        return this.Players.Where(x => x.PlayerId == i).FirstOrDefault().DargaId;
    }

    public string GetDargaName(int i)
    {
        return this.Dargas.Where(x => x.DargaId == GetDargaId(i)).FirstOrDefault().DargaName;
    }

    public void SetPlayerName(string? name, int i)
    {
        this.Players.Where(x => x.PlayerId == i).FirstOrDefault().PlayerName = name;
    }

    public void SetPlayerMail(string? mail, int i)
    {
        this.Players.Where(x => x.PlayerId == i).FirstOrDefault().Mail = mail;
    }

    public void SetPlayerPass(string? pass, int i)
    {
        this.Players.Where(x => x.PlayerId == i).FirstOrDefault().Pass = pass;
    }
}

