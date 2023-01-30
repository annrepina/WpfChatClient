﻿using CommonLib.NetworkServices;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMessengerServer.Responses
{
    /// <summary>
    /// Класс, который представляет данные представляющихе ответ на успешную регистрацию пользователя в мессенджере
    /// </summary>
    public class SignUpResponse : Response
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SignUpResponse(int userId, NetworkResponseStatus status) : base(status)
        {
            UserId = userId;
        }

        public SignUpResponse(NetworkResponseStatus status) : base(status)
        {
        }

        public SignUpResponse()
        {

        }
    }
}