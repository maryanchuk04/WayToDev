import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { first } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-upload-modal',
  templateUrl: './upload-modal.component.html',
  styleUrls: ['./upload-modal.component.css'],
})
export class UploadModalComponent implements OnInit {
  avatarUrl: string;
  color: string = '#fff';
  bgColor: string = '#000000';
  defaultData: AvatarData;

  defaultImages: string[] = [];

  constructor(
    public dialogRef: MatDialogRef<UploadModalComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: { firstName: string; lastName: string }
  ) {
    this.defaultData = {
      firstName: data.firstName,
      lastName: data.lastName,
      bgColor: this.bgColor,
      color: this.color,
    };

    this.changeAvatar(this.defaultData);

    for (let i = 1; i <= 6; i++)
      this.defaultImages.push(`${environment.defaultImagesUrl}${i}.jpg`);

    console.log(this.defaultImages);
  }

  ngOnInit(): void {
    console.log(this.data);
  }

  colorSelected(color: any) {
    this.color = color;
    this.changeAvatar({ ...this.defaultData, color, bgColor: this.bgColor });
  }

  bgColorSelected(bgColor: any) {
    this.bgColor = bgColor;
    this.changeAvatar({ ...this.defaultData, bgColor, color: this.color });
  }

  changeAvatar(data: AvatarData) {
    const { firstName, lastName, color, bgColor } = data;
    this.avatarUrl = `${
      environment.defaultImageAPI
    }/?name=${firstName}+${lastName}&color=${color.slice(
      1
    )}&background=${bgColor.slice(1)}&size=300`;
  }

  chooseDefaultImage(url: string) {
    this.avatarUrl = url;
  }
}

interface AvatarData {
  firstName: string;
  lastName: string;
  color: string;
  bgColor: string;
}
