﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DtoLib.NetworkServices;
using DtoLib.NetworkInterfaces;
using DtoLib;

namespace ConsoleMessengerServer.Net
{
    /// <summary>
    /// Сетевой провайдер на стороне сервера
    /// </summary>
    public class ServerNetworkProvider : NetworkProvider
    {
        /// <summary>
        /// Отвечает за работу с сетью
        /// </summary>
        public INetworkController NetworkController { get; set; }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="tcpClient">TCP клиент</param>
        /// <param name="networkController">Отвечает за работу с сетью</param>
        public ServerNetworkProvider(TcpClient tcpClient, INetworkController networkController)
        {
            TcpClient = tcpClient;
            NetworkStream = TcpClient.GetStream();
            NetworkController = networkController;
        }

        /// <summary>
        /// Начать обработку сетевых сообщений асинхронно
        /// </summary>
        public async Task StartProcessingNetworkMessagesAsync()
        {
            try
            {
                await Receiver.ReceiveNetworkMessageAsync();
            }
            catch (Exception)
            {
                Console.WriteLine($"Клиент Id {Id} отключился");
            }
            finally
            {
                NetworkController.DisconnectClient(Id);
                CloseConnection();
            }
        }

        /// <summary>
        /// Асинхронный метод получения сетевого сообщения
        /// </summary>
        /// <param name="message">Сетевое сообщение</param>
        /// <returns></returns>
        public override void GetNetworkMessage(NetworkMessage message)
        {
            if(message.CurrentCode == NetworkMessage.OperationCode.AuthorizationCode || message.CurrentCode == NetworkMessage.OperationCode.RegistrationCode)
                NetworkController.ProcessNetworkMessage(message, Id);
          
            else
                NetworkController.ProcessNetworkMessage(message);
        }
    }
}