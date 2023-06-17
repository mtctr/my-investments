FROM node as build-step
RUN mkdir -p /app
WORKDIR /app
COPY package.json /app

RUN npm install
COPY . /app
RUN npm run build --configuration=production

FROM nginx:latest
COPY default.conf /etc/nginx/conf.d
COPY --from=build-step /app/dist/my-investments /usr/share/nginx/html

EXPOSE 80