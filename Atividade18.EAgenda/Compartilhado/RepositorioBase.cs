﻿using Atividade18.EAgenda.Módulo_Contatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade18.EAgenda.Compartilhado
{
     public abstract class RepositorioBase<TEntidade> where TEntidade : EntidadeBase<TEntidade>
     {
          protected List<TEntidade> dados;
          protected int contadorId = 0;

          public virtual TEntidade SelecionarPorId(int id)
          {
               if (dados.Exists(registro => registro.id == id))
                    return dados.First(registro => registro.id == id);

               return null;
          }

          public virtual void Inserir(TEntidade registro)
          {
               contadorId++;
               registro.id = contadorId;
               dados.Add(registro);
          }

          public virtual void Remover(TEntidade registroSelecionado)
          {
               dados.Remove(registroSelecionado);
          }
          public virtual void Remover(int id)
          {
               TEntidade registroSelecionado = SelecionarPorId(id);

               if (registroSelecionado != null)
                    dados.Remove(registroSelecionado);
          }

          public virtual void Editar(int id, TEntidade registroAtualizado)
          {
               TEntidade registroSelecionado = SelecionarPorId(id);

               registroSelecionado.AtualizarRegistros(registroAtualizado);
          }
          public virtual void Editar(TEntidade registroSelecionado, TEntidade registroAtualizado)
          {
               registroSelecionado.AtualizarRegistros(registroAtualizado);
          }

          public virtual List<TEntidade> SelecionarRegistros()
          {
               return dados.OrderByDescending(x => x.id).ToList();
          }

          public virtual int RetornarContador()
          {
               return contadorId;
          }
     }
 
}