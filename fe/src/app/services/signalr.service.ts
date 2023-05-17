import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { MessageItem } from '../_interfaces/message-item.model';

@Injectable({
  providedIn: 'root'
})

export class SignalrService {
  public messageData: MessageItem[]

  private hubConnection: signalR.HubConnection
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                              .withUrl('https://localhost:7228/chatHub')
                              .build();
    this.hubConnection
    .start()
    .then(() => console.log('Connection started'))
    .catch(err => console.log('Error while starting connection:' + err))
  }

  // public sendMessage = () => {
  //   this.hubConnection.on('SendMessage', (data) => {
  //     this.messageData = data;
  //     console.log(data);
  //   }
  // }
}
