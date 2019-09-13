import { BaseEnvironment } from './environment.base';

export const PROD_OVERRIDES = {
  production: true
};

export const environment = { ...BaseEnvironment, ...PROD_OVERRIDES }
