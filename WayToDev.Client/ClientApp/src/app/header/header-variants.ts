import {Header} from "./models/header";
import {HeaderLink} from "./models/header-link";

const defaultLinks: HeaderLink[] =  [
  { route: "/", name: "Home" },
  { route: "news", name: "News" },
  { route: "sign-in", name: "SignIn" },
  { route: "sign-up", name: "SignUp" },
];



export const  defaultHeader: Header = {
  headerLinks: defaultLinks
}

export const companyHeader: Header = {
  headerLinks: [
    { route: "/", name: "Home" },
    { route: "news", name: "News" },
    { name: "Profile", route: "/profile-company"}
  ]
}

export const userHeader: Header = {
  headerLinks: [
    { route: "/", name: "Home" },
    { route: "feeds", name: "Feeds"},
    { route: "news", name: "News" },
    { route: "chats", name: "Chats"},
    { name: "Profile", route : "/profile"}
  ]
}

