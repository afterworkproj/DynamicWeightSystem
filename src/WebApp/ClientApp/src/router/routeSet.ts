﻿export interface ItemLink {
  icon: string;
  text: string;
  to: string;
  component: string;
  children?: ItemLink[];
}

const routeSet: ItemLink[] = [
  {
    icon: 'fas fa-home',
    text: 'Home',
    to: '/',
    component: 'index',
  },
  {
    icon: 'fa-solid fa-weight-hanging',
    text: '分規資訊管理',
    to: '/weight-level',
    component: 'weightLevel',
  },
  {
    icon: 'fas fa-gear',
    text: '魚種編號管理',
    to: '/fish-data',
    component: 'fishData',
  },
  {
    icon: 'fas fa-search',
    text: '歷史紀錄',
    to: '/history',
    component: 'history',
  },
];

export default routeSet;
