import { Component, OnInit } from '@angular/core';
import { UserListItem } from '../../models/userListItem'
@Component({
  selector: 'app-users-administrating',
  templateUrl: './users-administrating.component.html',
  styleUrls: ['./users-administrating.component.css']
})
export class UsersAdministratingComponent implements OnInit {
  usersList:UserListItem[] = [
    {
      userName: "MaksMaryanchuk",
      isDisabled: false,
      id: "sdsa2edwdsad123asasd",
      image: "https://t4.ftcdn.net/jpg/02/29/75/83/360_F_229758328_7x8jwCwjtBMmC6rgFzLFhZoEpLobB6L8.jpg"
    },
    {
      userName: "MaksMaryanchuk",
      isDisabled: true,
      id: "sdsa2edwdsad123asasd",
      image: "https://t4.ftcdn.net/jpg/02/29/75/83/360_F_229758328_7x8jwCwjtBMmC6rgFzLFhZoEpLobB6L8.jpg"
    },
    {
      userName: "MaksMaryanchuk",
      isDisabled: false,
      id: "sdsa2edwdsad123asasd",
      image: "https://t4.ftcdn.net/jpg/02/29/75/83/360_F_229758328_7x8jwCwjtBMmC6rgFzLFhZoEpLobB6L8.jpg"
    },
    {
      userName: "MaksMaryanchuk",
      isDisabled: true,
      id: "sdsa2edwdsad123asasd",
      image: "https://t4.ftcdn.net/jpg/02/29/75/83/360_F_229758328_7x8jwCwjtBMmC6rgFzLFhZoEpLobB6L8.jpg"
    },
    {
      userName: "MaksMaryanchuk",
      isDisabled: false,
      id: "sdsa2edwdsad123asasd",
      image: "https://t4.ftcdn.net/jpg/02/29/75/83/360_F_229758328_7x8jwCwjtBMmC6rgFzLFhZoEpLobB6L8.jpg"
    },
    {
      userName: "MaksMaryanchuk",
      isDisabled: true,
      id: "sdsa2edwdsad123asasd",
      image: "https://t4.ftcdn.net/jpg/02/29/75/83/360_F_229758328_7x8jwCwjtBMmC6rgFzLFhZoEpLobB6L8.jpg"
    },
    {
      userName: "MaksMaryanchuk",
      isDisabled: false,
      id: "sdsa2edwdsad123asasd",
      image: "https://t4.ftcdn.net/jpg/02/29/75/83/360_F_229758328_7x8jwCwjtBMmC6rgFzLFhZoEpLobB6L8.jpg"
    }
  ];
  constructor() { }

  ngOnInit(): void {
  }


}
