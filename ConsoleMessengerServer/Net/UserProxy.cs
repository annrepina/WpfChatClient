﻿using DtoLib.NetworkServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMessengerServer.Net
{
    /// <summary>
    /// Класс - аггрегатор всех соединений одного пользователя
    /// </summary>
    public class UserProxy
    {
        /// <summary>
        /// Событие - удалено последнее соединение
        /// </summary>
        public event Action<int> LastConnectionRemoved;

        /// <summary>
        /// Список сетевых провайдеров, которые подключены к серверу 
        /// и в которых выполнен вход в учетную запись пользователя
        /// </summary>
        private List<INetworkProvider> _connections;

        /// <summary>
        /// Свойство - идентификатор
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public UserProxy(int id)
        {
            Id = id;
            _connections = new List<INetworkProvider>();
        }

        /// <summary>
        /// Добавить соединение
        /// </summary>
        /// <param name="serverNetworkProvider">Сетевой провайдер, на котором произошло подключение</param>
        public void AddConnection(INetworkProvider serverNetworkProvider)
        {
            _connections.Add(serverNetworkProvider);
        }

        /// <summary>
        /// Удалить соединение с сетевым провайдером
        /// </summary>
        /// <param name="networkProviderId"></param>
        public bool TryRemoveConnection(int networkProviderId)
        {
            var provider = _connections.Find(pr => pr.Id == networkProviderId);
            
            if(provider != null)
                return _connections.Remove(provider);

            return false;
        }

        /// <summary>
        /// Транслировать асинхронно сетевое сообщение всем сетевым провайдерам на которых подключен пользователь
        /// </summary>
        /// <param name="networkMessage">Сетевое сообщение</param>
        public async Task BroadcastNetworkMessageAsync(byte[] messageBytes)
        {
            try
            {
                foreach (ServerNetworkProvider serverNetworkProvider in _connections)
                {
                    await serverNetworkProvider.SendBytesAsync(messageBytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Перегрузка метода BroadcastNetworkMessageToInterLocutorAsync
        /// Транслировать асинхронно сетевое сообщение всем сетевым провайдерам на которых подключен пользователь, кроме того, который передан в метод
        /// </summary>
        /// <param name="networkMessage">Сетевое сообщение</param>
        /// <param name="networkProvider">Сетевой провайдер на стороне сервера</param>
        /// <returns></returns>
        public async Task BroadcastNetworkMessageAsync(byte[] messageBytes, int networkProviderId)
        {
            try
            {
                foreach (ServerNetworkProvider serverNetworkProvider in _connections)
                {
                    if (serverNetworkProvider.Id != networkProviderId)
                        await serverNetworkProvider.SendBytesAsync(messageBytes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Отправить ответ на сетевой провайдер, от которого пришел запрос
        /// </summary>
        /// <param name="response"></param>
        /// <param name="netWorkProviderId"></param>
        /// <returns></returns>
        public async Task SendResponseAsync(byte[] response, int netWorkProviderId)
        {
            await _connections.First(con => con.Id == netWorkProviderId).SendBytesAsync(response);
        }

        /// <summary>
        /// Закрыть все соединения
        /// </summary>
        //public void CloseAll()
        //{
        //    foreach (var provider in _connections)
        //    {
        //        provider.CloseConnection();
        //    }
        //}
    }
}