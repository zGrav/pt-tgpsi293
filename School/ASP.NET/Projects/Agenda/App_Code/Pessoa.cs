using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for Pessoa
/// </summary>
public class Pessoa
{
	public Pessoa()
	{
		//
		// TODO: Add constructor logic here
		//

	}

   private string nome;
   private string email;
   private string telefone;

  public static ArrayList rtn = new ArrayList();

    public void load(string n, string e, string t)
    {
        nome = n;
        email = e;
        telefone = t;
    }

    public void add(Pessoa p) {
        rtn.Add(p);
    }

    public String getName()
    {
        return nome;
    }

    public String getMail()
    {
        return email;
    }

    public String getPhone()
    {
        return telefone;
    }

    public void delete(int d_i)
    {
        rtn.RemoveAt(d_i);
        
    }

    public void saveval(int d_i, string n, string e, string t)
    {
        int count = 0;
        foreach (Pessoa px in rtn_values())
        {
            if (count == d_i)
            {
                px.nome = n;
                px.email = e;
                px.telefone = t;
            }
            count++;
        }
    }

    public String searchval(string pes) 
    {
        int count = 0;
        string isFalse = "String não encontrada.";

        foreach (Pessoa px in rtn_values())
        {
            count++;
            if (px.nome.Contains(pes)) {
                String atNome;
                atNome = "String encontrada no nome! - corresponde a pessoa nº " + count.ToString();
                return atNome;
            }
            if (px.email.Contains(pes))
            {
                String atMail;
                atMail = "String encontrada no email! - corresponde a pessoa nº " + count.ToString();
                return atMail;
            }
            if (px.telefone.Contains(pes))
            {
                String atTel;
                atTel = "String encontrada no telefone! - corresponde a pessoa nº " + count.ToString();
                return atTel;
            }
        }
        return isFalse;
    }

    public void sortval()
    {
 
        Pessoa.rtn.Sort();
    }

    public Pessoa recval(int d_i)
    {
        int count = 0;
        Pessoa px2 = new Pessoa();
        foreach (Pessoa px in rtn_values())
        {
            if (count == d_i)
            {
                px2 = px;
            }
            count++;
        }
        return px2;
    }   

    public ArrayList rtn_values()
    {
        return rtn;
    }
}